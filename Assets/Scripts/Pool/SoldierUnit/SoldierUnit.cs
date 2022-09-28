using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUnit : SpawnableObject
{
	#region Fields
	[SerializeField] private Sprite soldierImage;
	private Sprite soldierSprite;
    private string soldierName;
    #endregion

    #region Props
    public Sprite SoldierSprite { get { return soldierSprite; } set { soldierSprite = value; } }
    public string SoldierName { get { return soldierName; } set { soldierName = value; } }
    #endregion
}
