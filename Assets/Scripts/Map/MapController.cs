using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static GameEnums;

public class MapController : Controller
{
    #region Fields
    [SerializeField] private GameObject placementPointsParent;
    [SerializeField] private List<PlacementPoint> placementPoints;
    [SerializeField] private ObjectPool buildingPool;
    [SerializeField] private float distThreshold = 1f;
    [SerializeField] private SoldierSpawnHelper spawnHelper;
    private Building building;
    #endregion

    #region Getters
    public List<PlacementPoint> PlacementPoints => placementPoints;
    #endregion

    #region Core
    public override void Initialize(GameplayData data)
    {
        for (int i = 0; i < placementPoints.Count; i++)
        {
            placementPoints[i].Initialize();
        }
    }
    public override void StartGame()
    {
        placementPointsParent.SetActive(true);

    }
    public override void GameOver()
    {
        placementPointsParent.SetActive(false);

    }
    #endregion

    #region Executes
    public PlacementPoint GetNearestPoint()
    {
        PlacementPoint nearestPoint = null;
        float nearestDistance = .5f;
        foreach (PlacementPoint point in placementPoints)
        {
            if (point.State == PlacementPointState.Empty)
            {
                float dist = Vector2.Distance(point.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (dist < nearestDistance)
                {
                    nearestPoint = point;
                    nearestDistance = dist;
                }
            }
        }
        return nearestPoint;
    }

    public void SpawnBuilding(StructureType type, Sprite itemImage, PlacementPoint point, string itemName, Sprite soldierSprite, string soldierName)
    {
        if (point.State == PlacementPointState.Empty)
        {
            point.SetState(PlacementPointState.Full);
            building = buildingPool.GetItem() as Building;
            building.SetBuildingData(itemImage, type, itemName);
            building.SetSoldierData(soldierSprite, soldierName);
            building.SetActiveWithPosition(point.transform.position);
            if (building.SpawnPoint != null) spawnHelper.Initialize(building.SpawnPoint);
        }
    }
    #endregion
}
