using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObject : MonoBehaviour
{
    #region Fields
    private bool isInUse;
    protected GameplayData data;
    public Transform defaultParent;
    #endregion

    #region Getters
    public bool IsInUse => isInUse;
    #endregion

    #region Core
    public virtual void Initialize(GameplayData data)
    {
        defaultParent = transform.parent;
        Dismiss();
        this.data = data;
    }
    public virtual void SetActive()
    {
        isInUse = true;
        gameObject.SetActive(true);
    }
    public virtual void SetActiveWithPosition(Vector2 pos)
    {
        isInUse = true;
        transform.position = pos;
        gameObject.SetActive(true);
    }
    public virtual void Dismiss()
    {
        isInUse = false;
        gameObject.SetActive(false);
        transform.SetParent(defaultParent);
    }
    #endregion
}
