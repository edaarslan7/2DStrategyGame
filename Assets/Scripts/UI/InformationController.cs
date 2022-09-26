using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameEnums;

public class InformationController : Controller
{
    #region Fields
    [Header("Information")]
    [SerializeField] private Text itemName;
    [SerializeField] private Image itemImage;
    [SerializeField] private Image soldierImage;
    [SerializeField] private GameObject product;
    [SerializeField] private GameObject structure;
    [Space]
    [SerializeField] private MapController mapController;
    [SerializeField] private InfiniteScroll scroll;
    private StructureType structureType;
    private ScrollViewItem item;
    private bool buttonInteractable;
    #endregion

    #region Core
    public override void Initialize(GameplayData data)
    {
    }

    public override void StartGame()
    {
    }
    public override void GameOver()
    {
    }

    #endregion

    public void SetScrollViewItem(ScrollViewItem item)
    {
        this.item = item;
    }

    #region Executes
    public void SetInformationData(string name, Sprite image, StructureType type, bool buttonInteractable)
    {
        this.buttonInteractable = buttonInteractable;
        if (!structure.activeInHierarchy) structure.SetActive(true);
        itemName.text = name;
        itemImage.sprite = image;
        this.structureType = type;
        if (structureType == StructureType.Barrack)
        {
            if (!product.activeInHierarchy)
                product.SetActive(true);
        }
        else
        {
            if (product.activeInHierarchy)
                product.SetActive(false);
        }
    }

    public void OnClick()
    {
        if (buttonInteractable)
        {
            Building building = mapController.SpawnBuilding(structureType, itemImage.sprite);
        }
    }
    #endregion

}