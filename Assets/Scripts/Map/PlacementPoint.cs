using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnums;

public class PlacementPoint : MonoBehaviour
{
	#region Fields
	private PlacementPointState state;
    private Building currentBuilding;
    #endregion

    #region Props
    public Building CurrentBuilding { get { return currentBuilding; } set { currentBuilding = value; } }
    #endregion

    #region Getters
    public PlacementPointState State => state;
	#endregion

	#region Core
	public void Initialize()
	{
		state = PlacementPointState.Empty;
	}
	#endregion

	#region Execute
	public void SetState(PlacementPointState state)
	{
		this.state = state;
	}
	#endregion
}
