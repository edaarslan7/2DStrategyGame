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
	[SerializeField] List<PlacementPoint> placementPoints;
    [SerializeField] ObjectPool buildingPool;
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
    public Building SpawnBuilding(StructureType type, Sprite itemImage)
    {
        bool any = placementPoints.Any(x => x.State == GameEnums.PlacementPointState.Empty);
        if (any)
        {
            PlacementPoint emptyZone = placementPoints.First(x => x.State == GameEnums.PlacementPointState.Empty);
            Building building = buildingPool.GetItem() as Building;
            building.SetBuildingData(itemImage, type);
            building.SetActiveWithPosition(emptyZone.transform.position);
            emptyZone.SetState(GameEnums.PlacementPointState.Full);

            return building;
        }
        else
        {
            return null;
        }
    }
    #endregion
}
