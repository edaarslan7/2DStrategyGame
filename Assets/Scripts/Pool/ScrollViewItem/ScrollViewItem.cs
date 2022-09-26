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
    #endregion

    #region Props
    public Image Image { get { return image; } set { image = value; } }

    #endregion

    #region Core
    //protected override void setStructureData()
    //{
    //    base.setStructureData();
    //    int randomStructureImage;

    //    switch (randomType)
    //    {
    //        case 0:
    //            randomStructureImage = Rnd.Range(0, data.Buildings.Count);
    //            image.sprite = data.Buildings[randomStructureImage];
    //            break;
    //        case 1:
    //            randomStructureImage = Rnd.Range(0, data.PowerPlants.Count);
    //            image.sprite = data.PowerPlants[randomStructureImage];
    //            break;
    //        case 2:
    //            randomStructureImage = Rnd.Range(0, data.Barracks.Count);
    //            image.sprite = data.Barracks[randomStructureImage];
    //            break;
    //    }
    //}
    #endregion

    #region Executes
    public override void OnItemClick()
    {
        base.OnItemClick();
        information.SetInformationData(type.ToString(), image.sprite, type, true); ;
        information.SetScrollViewItem(this);
    }
    #endregion
}
