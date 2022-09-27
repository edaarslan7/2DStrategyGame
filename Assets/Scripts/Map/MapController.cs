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

    public void SpawnBuilding(StructureType type, Sprite itemImage, PlacementPoint point)
    {
        bool a = point.State == PlacementPointState.Empty;
        //print(a + " " + point.State + " " + point);
        if (point.State == PlacementPointState.Empty)
        {
            point.SetState(PlacementPointState.Full);
            building = buildingPool.GetItem() as Building;
            building.SetBuildingData(itemImage, type);
            building.SetActiveWithPosition(point.transform.position);
        }
        else
        {
        }
    }
    #endregion




    //public Building SpawnBuilding(StructureType type, Sprite itemImage)
    //{
    //    bool any = placementPoints.Any(x => x.State == GameEnums.PlacementPointState.Empty);
    //    if (any)
    //    {
    //        PlacementPoint emptyZone = placementPoints.First(x => x.State == GameEnums.PlacementPointState.Empty);
    //        Building building = buildingPool.GetItem() as Building;
    //        building.SetBuildingData(itemImage, type);
    //        building.SetActiveWithPosition(emptyZone.transform.position);
    //        emptyZone.SetState(GameEnums.PlacementPointState.Full);

    //        return building;
    //    }
    //    else
    //    {
    //        return null;
    //    }
    //}
}
