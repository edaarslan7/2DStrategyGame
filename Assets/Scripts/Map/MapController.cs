using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : Controller
{
	#region Fields
	[SerializeField] List<PlacementPoint> placementPoints;
    #endregion

	#region Core
	public override void Initialize(GameplayData data)
	{
		for (int i = 0; i < placementPoints.Count; i++)
		{
			placementPoints[i].Initialize();
		}
	}
	public override void StartGame()
	{
	}
    public override void GameOver()
    {
    }
	#endregion
}
