using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnums;

public class Building : SpawnableObject
{
    #region Fields
    [Header("Components")]
    [SerializeField] private BuildingBody body;
    [Header("Modules")]
    [SerializeField] private PlacementModule placementModule;
    private List<PlacementPoint> placementPoints;
    private StructureType type;
    #endregion

    #region Getters
    public PlacementModule PlacementModule => placementModule;
    public List<PlacementPoint> PlacementPoints => placementPoints;
    #endregion

    #region Core
    public override void Initialize(GameplayData data)
    {
        base.Initialize(data);
        body.Initialize(data);
    }
    public override void SetActiveWithPosition(Vector2 pos)
    {
        base.SetActiveWithPosition(pos);
        placementPoints = new List<PlacementPoint>();
        placementModule.Initialize(this, body);
    }
    public override void Dismiss()
    {
        base.Dismiss();
        placementModule.CanPlace = false;
    }
    public void SetBuildingData(Sprite image, StructureType type)
    {
        body.MainRenderer.sprite = image;
        this.type = type;
    }
    #endregion

    #region Input
    public void OnClick()
    {
        body.ColorChangings(false);

        placementModule.OnClick();

        setPlacementPoints(true);

        body.MainRenderer.sortingOrder = 99;
    }
    public void OnClickEnd(Vector3 returnPos)
    {
        if (placementModule.CanPlace)
        {
            placementModule.OnClickEnd();
            setPlacementPoints(false);
        }
        else
        {
            placementModule.ReturnClickPos(returnPos);
        }

        body.MainRenderer.sortingOrder = 0;

    }
    #endregion

    #region ListUpdate
    private void addNewPlacementPoint(PlacementPoint point)
    {
        if (!placementPoints.Contains(point))
            placementPoints.Add(point);

        placementModule.UpdateCanPlace();
    }
    private void removePlacementPoint(PlacementPoint point)
    {
        if (placementPoints.Contains(point))
            placementPoints.Remove(point);

        placementModule.UpdateCanPlace();
    }
    private void setPlacementPoints(bool isEmpty)
    {
        if (placementPoints.Count > 0)
        {
            for (int i = 0; i < placementPoints.Count; i++)
            {
                PlacementPoint point = placementPoints[i].GetComponent<PlacementPoint>();
                if (isEmpty)
                {
                    point.SetState(GameEnums.PlacementPointState.Empty);
                    placementModule.IsPlaced = false;
                }
                else
                {
                    point.SetState(GameEnums.PlacementPointState.Full);
                    placementModule.IsPlaced = true;
                }
            }
        }
    }
    #endregion

    #region Physics
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(CONSTANTS.placementPointTag))
        {
            addNewPlacementPoint(other.GetComponent<PlacementPoint>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(CONSTANTS.placementPointTag))
        {
            removePlacementPoint(other.GetComponent<PlacementPoint>());
        }
    }
    #endregion
}
