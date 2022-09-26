using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Diagnostics;

public class PlacementModule : MonoBehaviour
{
    #region Fields
    [Header("Placement Module Fields")]
    public Action<Building> OnPlaced;
    public Action<Building> OnUnPlaced;
    private Building building;
    private BuildingBody body;
    private bool isPlaced;
    private bool canPlace;
    #endregion

    #region Props
    public bool IsPlaced { get { return isPlaced; } set { isPlaced = value; } }
    public bool CanPlace { get { return canPlace; } set { canPlace = value; } }
    #endregion

    #region Core
    public void Initialize(Building building, BuildingBody body)
    {
        this.building = building;
        this.body = body;
    }
    public void OnClick()
    {
        OnUnPlaced?.Invoke(building);
    }
    public void OnClickEnd()
    {
        OnPlaced?.Invoke(building);
        body.ResetColor();
    }
    #endregion

    #region Executes
    public void ReturnClickPos(Vector3 returnPos)
    {
        isPlaced = true;
        transform.position = returnPos;
        body.ResetColor();
    }
    #endregion

    #region Controls
    public void UpdateCanPlace()
    {
        if (building.PlacementPoints.Count > 0)
        {
            if (building.PlacementPoints.All(x => x.State == GameEnums.PlacementPointState.Empty))
                CanPlace = true;
        }
        else
            CanPlace = false;

        body.ColorChangings(CanPlace);
    }
    #endregion
}
