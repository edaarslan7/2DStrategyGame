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
    private string structureName;
    private StructureType type;
    private InformationController information;
    #endregion

    #region Core
    public override void SetActive()
    {
        base.SetActive();
        setStructureData();
        information = FindObjectOfType<InformationController>();
    }
    private void setStructureData()
    {
        int randomType = Rnd.Range(0, CONSTANTS.COUNT);
        type = (StructureType)randomType;
        structureName = type.ToString();

        int randomStructureImage;

        switch (randomType)
        {
            case 0:
                randomStructureImage = Rnd.Range(0, data.Buildings.Count);
                image.sprite = data.Buildings[randomStructureImage];
                break;
            case 1:
                randomStructureImage = Rnd.Range(0, data.PowerPlants.Count);
                image.sprite = data.PowerPlants[randomStructureImage];
                break;
            case 2:
                randomStructureImage = Rnd.Range(0, data.Barracks.Count);
                image.sprite = data.Barracks[randomStructureImage];
                break;
        }
    }
    #endregion

    #region Execute
    public void OnClick()
    {
        information.SetInformationData(structureName, image.sprite, type, this);
    }
    #endregion
}
