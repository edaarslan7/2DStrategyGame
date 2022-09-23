using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScreen : GameScreen
{
    #region Fields
    [SerializeField] private InfiniteScroll scroll;
    #endregion

    #region Core
    public override void Show()
    {
        base.Show();
        scroll.Initialize();
    }
    #endregion

    #region Execute
    public void OnClick()
    {
        
    }
    #endregion
}
