using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameEnums;

public class SpawnableObject : MonoBehaviour
{
    #region Fields
    private Transform defaultParent;
    private bool isInUse;
    protected StructureType type;
    protected int randomType;
    protected GameplayData data;
    protected InformationController information;
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
        information = FindObjectOfType<InformationController>();
    }
    public virtual void SetActive()
    {
        isInUse = true;
        setStructureData();
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
    protected virtual void setStructureData()
    {
        randomType = Random.Range(0, CONSTANTS.COUNT);
        type = (StructureType)randomType;
        
    }
    #endregion

    #region Executes
    public virtual void OnItemClick()
    {
    }
    #endregion
}
