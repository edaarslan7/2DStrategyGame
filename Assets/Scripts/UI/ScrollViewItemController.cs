using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnums;

public class ScrollViewItemController : Controller
{
    #region Fields
    [SerializeField] private InfiniteScroll scroll;
    [SerializeField] private ObjectPool itemsPool;
    private GameplayData gameplayData;
    List<Transform> items = new List<Transform>();
    private int buildingCount;
    private int barrackCount;
    private int powerPlantCount;
    #endregion

    #region Core
    public override void Initialize(GameplayData data)
    {
        gameplayData = data;
        buildingCount = data.Buildings.Count;
        barrackCount = data.Barracks.Count;
        powerPlantCount = data.PowerPlants.Count;
    }
    public override void StartGame()
    {
    }
    public override void GameOver()
    {
    }
    #endregion

    #region Executes
    public void SetItems()
    {
        createItem(buildingCount, StructureType.Building);
        createItem(barrackCount, StructureType.Barrack);
        createItem(powerPlantCount, StructureType.PowerPlant);

        scroll.SetNewItems(items, true);
    }

    private void createItem(int count, StructureType type)
    {
        for (int i = 0; i < count; i++)
        {
            ScrollViewItem obj = itemsPool.GetItem() as ScrollViewItem;
            switch (type)
            {
                case StructureType.Building:
                    obj.Type = StructureType.Building;
                    obj.Image.sprite = gameplayData.Buildings[i];
                    break;
                case StructureType.PowerPlant:
                    obj.Type = StructureType.PowerPlant;
                    obj.Image.sprite = gameplayData.PowerPlants[i];
                    break;
                case StructureType.Barrack:
                    obj.Type = StructureType.Barrack;
                    obj.Image.sprite = gameplayData.Barracks[i];
                    int randomSoldier = Random.Range(0, gameplayData.Soldiers.Count);
                    obj.SoldierSprite = gameplayData.Soldiers[randomSoldier];
                    obj.SoldierName = "Soldier " + (randomSoldier+1);
                    break;
            }
            obj.StructureName = obj.Type + " " + (i + 1);
            obj.SetActive();
            items.Add(obj.transform);
        }
    }
    #endregion
}
