using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoadingScreen : GameScreen
{
    #region Fields
    private const float loadingTime = 2f;
    [SerializeField] private UnityEvent onLoaded;
    #endregion

    #region Core
    public override void Show()
    {
        base.Show();
        StartCoroutine(LoadingDelay());
    }

    private IEnumerator LoadingDelay()
    {
        yield return new WaitForSeconds(loadingTime);
        onLoaded?.Invoke();
        Hide();
    }
    #endregion
}
