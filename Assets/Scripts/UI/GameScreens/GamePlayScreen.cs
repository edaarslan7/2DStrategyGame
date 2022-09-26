using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScreen : GameScreen
{
    #region Fields
    [SerializeField] private InfiniteScroll scroll;
    [SerializeField] private ScrollViewItemController scrollItemController;
    #endregion

    #region Core
    public override void Show()
    {
        base.Show();
        scroll.Initialize();
        scrollItemController.SetItems();
    }
    #endregion

    private void setItems()
    {

    }
}
