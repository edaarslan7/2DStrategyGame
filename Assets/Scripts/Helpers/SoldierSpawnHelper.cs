using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierSpawnHelper : MonoBehaviour
{
	#region Fields
	[SerializeField] private ObjectPool soldierPool;
	[SerializeField] private Image soldierImage;
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
		soldier.SetSprite(soldierImage.sprite);
		soldier.SetActiveWithPosition(spawnPoint.position);
	}
	#endregion

}
