using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    #region Fields
    [SerializeField] private InputModule inputModule;
    [SerializeField] private GridModule gridModule;
    private GameObject currentBuilding;
    private GameObject currentSoldier;
    private Building building;
    private SoldierUnit soldierUnit;
    #endregion

    #region Core
    public override void Initialize(GameplayData data)
    {
        inputModule.IsActive = true;
    }
    public override void StartGame()
    {
        inputModule.OnClicked += OnClicked;
        inputModule.OnDragged += OnDragged;
        inputModule.OnClickEnded += OnClickEnded;
        inputModule.OnSoldierClicked += SetSoldier;
        inputModule.OnSoldierMovement += SetSoldierMovement;
    }
    public override void GameOver()
    {
        inputModule.OnClicked -= OnClicked;
        inputModule.OnDragged -= OnDragged;
        inputModule.OnClickEnded -= OnClickEnded;
        inputModule.OnSoldierClicked -= SetSoldier;
        inputModule.OnSoldierMovement -= SetSoldierMovement;
    }
    #endregion

    #region Input
    public void OnClicked(GameObject obj, Vector2 pos)
    {
        currentBuilding = obj;
        building = currentBuilding.GetComponent<Building>();
        building.OnClick();
    }
    public void OnDragged(Vector2 pos)
    {
        Vector2 placePos = new Vector2(gridModule.RoundToNearest(pos.x), gridModule.RoundToNearest(pos.y));
        currentBuilding.transform.position = placePos;
    }
    public void OnClickEnded()
    {
        Vector2 returnPos = new Vector2(inputModule.ClickPos.x, inputModule.ClickPos.y);
        building.OnClickEnd(returnPos);
        currentBuilding = null;
    }
    public void SetSoldier(GameObject soldier)
    {
        currentSoldier = soldier;
    }
    public void SetSoldierMovement(Vector2 pos)
    {
        soldierUnit=currentSoldier.GetComponent<SoldierUnit>();
        soldierUnit.Movement(pos);
    }
    #endregion
}
