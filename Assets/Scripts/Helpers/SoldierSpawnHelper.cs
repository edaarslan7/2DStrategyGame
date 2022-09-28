using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawnHelper : MonoBehaviour
{
	#region Fields
	[SerializeField] private ObjectPool soldierPool;
	private Transform spawnPoint;
	#endregion

	#region Core
	public void Initialize(Transform point)
	{
		spawnPoint = point;
	}
	#endregion

	#region Executes
	public void SpawnSoldier()
	{
		SoldierUnit soldier = soldierPool.GetItem() as SoldierUnit;
		soldier.SetActiveWithPosition(spawnPoint.position);
	}
	#endregion

}
