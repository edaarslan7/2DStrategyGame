using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    #region Fields
    [SerializeField] private InputModule inputModule;
    [SerializeField] private GridModule gridModule;
    private GameObject currentObj;
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
    }
    public override void GameOver()
    {
        inputModule.OnClicked -= OnClicked;
        inputModule.OnDragged -= OnDragged;
        inputModule.OnClickEnded -= OnClickEnded;
    }
    #endregion

    #region Input
    public void OnClicked(GameObject obj, Vector2 pos)
    {
        currentObj = obj;
        Building building = currentObj.GetComponent<Building>();
        building.OnClick();
    }
    public void OnDragged(Vector2 pos)
    {
        Vector2 placePos = new Vector2(gridModule.RoundToNearest(pos.x), gridModule.RoundToNearest(pos.y));
        currentObj.transform.position = placePos;
    }
    public void OnClickEnded()
    {
        Building building = currentObj.GetComponent<Building>();
        Vector2 returnPos = new Vector2(inputModule.ClickPos.x, inputModule.ClickPos.y);
        building.OnClickEnd(returnPos);
        currentObj = null;
    }
    #endregion
}