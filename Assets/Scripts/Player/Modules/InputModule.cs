using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputModule : MonoBehaviour
{
    #region Fields
    public Action<GameObject, Vector2> OnClicked;
    public Action<Vector2> OnDragged;
    public Action OnClickEnded;
    public Action<GameObject> OnSoldierClicked;
    public Action<Vector2> OnSoldierMovement;
    [SerializeField] private GameObject itemplace;
    [SerializeField] private LayerMask buildingLayer;
    [SerializeField] private LayerMask soldierLayer;
    [SerializeField] private float dragThreshold = 1f;
    [SerializeField] private ItemPlaceHelper itemPlaceHelper;
    private Vector2 currentPos;
    private Vector2 clickPos;
    private GameObject building;
    private GameObject soldierUnit;
    #endregion

    #region Getters
    public Vector2 ClickPos => clickPos;
    #endregion

    #region Props
    public bool IsActive { get; set; }
    #endregion

    #region Core
    public void Initialize()
    {
    }
    #endregion

    #region Executes
    private void Update()
    {
        if (IsActive)
        {
            if (!itemplace.activeInHierarchy)
                MouseExecute();
        }
    }
    private void MouseExecute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
        if (Input.GetMouseButton(0))
        {
            OnDrag();
        }
        if (Input.GetMouseButtonUp(0))
        {
            OnClickEnd();
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = createRaycast(soldierLayer);
            if (hit.collider != null)
                soldierUnit = hit.collider.transform.parent.gameObject;
            else
                soldierUnit = null;
            OnSoldierClicked?.Invoke(soldierUnit);
        }
    }

    private RaycastHit2D createRaycast(LayerMask layer)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layer);
        return hit;
    }

    private void OnClick()
    {
        RaycastHit2D hit = createRaycast(buildingLayer);
        if (hit.collider != null)
        {
            building = hit.collider.transform.parent.parent.gameObject;
            clickPos = new Vector2(building.transform.position.x, building.transform.position.y);
            OnClicked?.Invoke(building, clickPos);

            //Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
        }
        else
        {
            clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (soldierUnit != null)
            {
                itemPlaceHelper.ClickAnim(clickPos);
                OnSoldierMovement?.Invoke(clickPos);
            }
        }
        //else
        //{
        //    Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
        //}
    }

    private void OnDrag()
    {
        if (building != null)
        {
            currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float dragValue = Vector2.SqrMagnitude(new Vector2(clickPos.x, clickPos.y) - currentPos);
            if (dragValue > dragThreshold)
                OnDragged?.Invoke(new Vector2(currentPos.x, currentPos.y));
        }
    }

    private void OnClickEnd()
    {
        if (building != null)
        {
            OnClickEnded?.Invoke();
            building = null;
        }
    }
    #endregion

}
