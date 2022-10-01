using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameEnums;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ItemPlaceHelper : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject model;
    [SerializeField] private SpriteRenderer itemRenderer;
    [SerializeField] private MapController mapController;
    [SerializeField] private Transform returnPoint;
    private string itemName;
    private string soldierName;
    private Sprite soldierSprite;
    private PlacementPoint point;
    private StructureType structureType;
    bool canPlace;
    #endregion

    #region Core
    public void Initialize()
    {
        SetModel(false);
    }
    #endregion

    #region Update
    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        model.transform.position = mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            point = mapController.GetNearestPoint();
            if (point != null && canPlace)
            {
                mapController.SpawnBuilding(structureType, itemRenderer.sprite, point, itemName, soldierSprite, soldierName);
                SetModel(false);
            }
        }

    }
    #endregion

    #region Executes
    public void SetItemData(Sprite sprite, StructureType type, string itemName)
    {
        itemRenderer.sprite = sprite;
        structureType = type;
        this.itemName = itemName;
    }

    public void SetSoldierData(Sprite soldierSprite, string soldierName)
    {
        this.soldierSprite = soldierSprite;
        this.soldierName= soldierName;
    }

    public void SetModel(bool value)
    {
        model.SetActive(value);
        Cursor.visible = !value;
        canPlace = value;
    }
    public void SetScale(Vector2 scale)
    {
        model.transform.localScale = scale;
    }
    #endregion
}
