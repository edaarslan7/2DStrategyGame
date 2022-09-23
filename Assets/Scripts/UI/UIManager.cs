using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameScreen[] screens;
    private GameScreen activeScreen;
    #endregion

    #region Core
    public void Initialize()
    {
        foreach (var screen in screens)
        {
            screen.gameObject.SetActive(true);
        }
    }
    #endregion

    #region Screen Executes
    public void ChangeScreen(GameEnums.ScreenTags screenType)
    {
        if (ReferenceEquals(activeScreen, null))
        {
            activeScreen = screens[(int)screenType];
            activeScreen.Show();
        }
        else
        {
            if (screens[(int)screenType] == activeScreen)
            {
                return;
            }
            activeScreen.Hide();
            activeScreen = screens[(int)screenType];
            activeScreen.Show();
        }
    }
    #endregion
}
