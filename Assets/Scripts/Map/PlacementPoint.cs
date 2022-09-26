using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnums;

public class PlacementPoint : MonoBehaviour
{
	#region Fields
	[SerializeField]private PlacementPointState state;
    #endregion

    #region Getters
    public PlacementPointState State => state;
	#endregion

	#region Core
	public void Initialize()
	{
	}
	#endregion

	#region Execute
	public void SetState(PlacementPointState state)
	{
		this.state = state;
	}
	#endregion
}
