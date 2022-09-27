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
    private PlacementPoint point;
    private StructureType structureType;
    bool canPlace;
    #endregion

    public void Initialize()
    {
        SetModel(false);
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        model.transform.position = mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            point = mapController.GetNearestPoint();
            if (point != null && canPlace)
            {
                mapController.SpawnBuilding(structureType, itemRenderer.sprite, point);
                SetModel(false);
            }
        }

    }

    public void SetItemData(Sprite sprite, StructureType type)
    {
        itemRenderer.sprite = sprite;
        structureType = type;
    }

    public void SetModel(bool value)
    {
        model.SetActive(value);
        Cursor.visible = !value;
        canPlace = value;

    }
}
