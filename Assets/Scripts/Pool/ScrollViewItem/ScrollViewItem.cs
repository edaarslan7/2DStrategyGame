using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameEnums;
using Rnd = UnityEngine.Random;
public class ScrollViewItem : SpawnableObject
{
    #region Fields
    [SerializeField] private Image image;
    private StructureType type;
    private string structureName;
    private Sprite soldierSprite;
    private string soldierName;
    #endregion

    #region Props
    public Image Image { get { return image; } set { image = value; } }
    public Sprite SoldierSprite { get { return soldierSprite; } set { soldierSprite = value; } }
    public StructureType Type { get { return type; } set { type = value; } }
    public string StructureName { get { return structureName; } set { structureName = value; } }
    public string SoldierName { get { return soldierName; } set { soldierName = value; } }
    #endregion

    #region Core
    #endregion

    #region Executes
    public override void OnItemClick()
    {
        base.OnItemClick();
        information.SetInformationData(structureName, image.sprite, type, true);
        if (type == StructureType.Barrack)
            information.SetSoldierData(soldierSprite, soldierName);
        information.SetScrollViewItem(this);
    }
    #endregion
}
