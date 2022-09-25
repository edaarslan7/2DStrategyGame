using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    [SerializeField] private ObjectPool itemsPool;
    [SerializeField] private ObjectPool buildingPool;
    [SerializeField] private InfiniteScroll scroll;
    [SerializeField] private MapController mapController;
    [SerializeField] int count;
    List<Transform> items = new List<Transform>();
    int index = 1;
    private List<PlacementPoint> placementPoints;
    private void Start()
    {
        placementPoints = mapController.PlacementPoints;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            index++;
            if (index > 3) index = 1;
            GameEnums.GameStates state = (GameEnums.GameStates)index;
            GameManager.Instance.ChangeGameState(state);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            for (int i = 0; i < count; i++)
            {
                SpawnableObject obj = itemsPool.GetItem();
                obj.SetActive();
                items.Add(obj.transform);
            }
            scroll.SetNewItems(items, true);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            spawnBuilding();
        }
    }
    private Building spawnBuilding()
    {
        bool any = placementPoints.Any(x => x.State == GameEnums.PlacementPointState.Empty);
        if (any)
        {
            PlacementPoint emptyZone = placementPoints.First(x => x.State == GameEnums.PlacementPointState.Empty);

            Building building = buildingPool.GetItem() as Building;
            building.SetActiveWithPosition(emptyZone.transform.position);

            emptyZone.SetState(GameEnums.PlacementPointState.Full);

            building.BuildingBody.ResetColor();
            return building;
        }
        else
        {
            return null;
        }
    }
}
