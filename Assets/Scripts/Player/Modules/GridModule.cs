using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridModule : MonoBehaviour
{
    #region Fields
    [Header("Grid Fields")]
    [SerializeField] private float gridSize;
    #endregion

    #region Execute
    public float RoundToNearest(float value)
    {
        float xDiff = value % gridSize;
        value -= xDiff;
        return value;
    }
    #endregion
}
