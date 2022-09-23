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
    [SerializeField] private LayerMask layer;
    private Vector2 currentPos;
    private Vector2 clickPos;
    private GameObject obj;
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
    }

    private void OnClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layer);
        if (hit.collider != null)
        {
            clickPos = new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
            obj = hit.collider.transform.parent.gameObject;
            OnClicked?.Invoke(obj, clickPos);

            //Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
        }
        //else
        //{
        //    Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
        //}
    }

    private void OnDrag()
    {
        if (obj != null)
        {
            currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            OnDragged?.Invoke(new Vector2(currentPos.x, currentPos.y));
        }
    }

    private void OnClickEnd()
    {
        if (obj != null)
        {
            OnClickEnded?.Invoke();
            obj = null;
        }
    }
    #endregion

}
