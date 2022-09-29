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
    [SerializeField] private Text soldierName;
    [SerializeField] private GameObject product;
    [SerializeField] private GameObject structure;
    [SerializeField] private Button soldierButton;
    [Header("Controllers/Helpers")]
    [SerializeField] private MapController mapController;
    [SerializeField] private InfiniteScroll scroll;
    [SerializeField] private ItemPlaceHelper itemPlaceHelper;
    private StructureType structureType;
    private ScrollViewItem item;
    private bool buttonInteractable;
    #endregion

    #region Core
    public override void Initialize(GameplayData data)
    {
        itemPlaceHelper.Initialize();
    }

    public override void StartGame()
    {
    }
    public override void GameOver()
    {
    }
    #endregion

    #region Executes
    public void SetScrollViewItem(ScrollViewItem item)
    {
        this.item = item;
    }
    public void SetInformationData(string name, Sprite image, StructureType type, bool buttonInteractable)
    {
        this.buttonInteractable = buttonInteractable;
        soldierButton.interactable = !buttonInteractable;
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

    public void SetSoldierData(Sprite soldier, string soldierName)
    {
        soldierImage.sprite = soldier;
        this.soldierName.text = soldierName;
    }

    public void OnClick(Building building)
    {
        if (buttonInteractable)
        {
            itemPlaceHelper.SetItemData(itemImage.sprite, structureType, itemName.text);
            itemPlaceHelper.SetSoldierData(soldierImage.sprite, soldierName.text);
            itemPlaceHelper.SetModel(true);
        }
    }
    #endregion
}