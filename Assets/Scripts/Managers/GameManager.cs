using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnums;

public class GameManager : MonoBehaviour
{
	#region Fields
	[SerializeField] GameCoordinator gameCoordinator;
	[SerializeField] UIManager uiManager;
    public static GameManager Instance;
    private GameStates currentGameState;
    #endregion

    #region Getters
    public GameStates CurrentGameState => currentGameState;
    #endregion

    #region Core
    public void Initialize()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        gameCoordinator.Initialize();
        uiManager.Initialize();
        ChangeGameState(GameStates.Loading);
    }

    private void Awake()
    {
        Initialize();
    }
    #endregion

    #region State Executes
    public void ChangeGameState(GameStates state)
    {
        currentGameState = state;
        OnGameStateChanged();
    }

    private void OnGameStateChanged()
    {
        switch (currentGameState)
        {
            case GameStates.Loading:
                Loading();
                break;
            case GameStates.GamePlay:
                GamePlay();
                break;
            case GameStates.GameEnd:
                GameEnd();
                break;
        }
    }

    private void Loading()
    {
        uiManager.ChangeScreen(ScreenTags.LoadingScreen);
    }

    private void GamePlay()
    {
        gameCoordinator.StartGame();
        uiManager.ChangeScreen(ScreenTags.GamePlayScreen);
    }

    private void GameEnd()
    {
        gameCoordinator.GameOver();
        uiManager.ChangeScreen(ScreenTags.GameEndScreen);
    }
    #endregion

    public void OnGameLoaded()
    {
        ChangeGameState(GameStates.GamePlay);
    }
}
