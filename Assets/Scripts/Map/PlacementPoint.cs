using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnums;

public class PlacementPoint : MonoBehaviour
{
	#region Fields
	[SerializeField]private PlacementPointState state;
	[SerializeField] private GameObject model;
    #endregion

    #region Getters
    public PlacementPointState State => state;
	#endregion

	#region Core
	public void Initialize()
	{
		//state = PlacementPointState.Empty;
	}
	#endregion

	#region Execute
	public void SetState(PlacementPointState state)
	{
		this.state = state;
		if(state==PlacementPointState.Full) model.SetActive(false);
		else model.SetActive(true);
	}
	#endregion
}
