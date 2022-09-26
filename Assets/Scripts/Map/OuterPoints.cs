using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnums;

public class OuterPoints : MonoBehaviour
{
    #region Fields
    [SerializeField] private PlacementPointState state;
    #endregion

    #region Getters
    public PlacementPointState State => state;
    #endregion

    #region Core
    public void Initialize()
    {
    }
    #endregion
}
