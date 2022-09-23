using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameCoordinator : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameplayData gameData;
    [SerializeField] private List<Controller> controllers;
    #endregion

    #region Core
    public void Initialize()
    {
        controllers.ForEach(x => x.Initialize(gameData));
    }
    public void StartGame()
    {
        controllers.ForEach(x => x.StartGame());
    }
    public void GameOver()
    {
        controllers.ForEach(x => x.GameOver());
    }
    #endregion
}
