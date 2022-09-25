using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapController : Controller
{
	#region Fields
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
	}
    public override void GameOver()
    {
    }
    #endregion

    #region Executes
    public Building SpawnBuilding()
    {
        bool any = placementPoints.Any(x => x.State == GameEnums.PlacementPointState.Empty);
        if (any)
        {
            PlacementPoint emptyZone = placementPoints.First(x => x.State == GameEnums.PlacementPointState.Empty);
            emptyZone.SetState(GameEnums.PlacementPointState.Full);
            Building building = buildingPool.GetItem() as Building;
            building.SetActiveWithPosition(emptyZone.transform.position);

            return building;
        }
        else
        {
            return null;
        }
    }
    #endregion
}
