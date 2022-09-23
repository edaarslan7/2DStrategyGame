using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class Controller : MonoBehaviour
{
    #region Fields
    #endregion

    #region Core
    public abstract void Initialize(GameplayData data);
    public abstract void StartGame();
    public abstract void GameOver();
    #endregion
}
