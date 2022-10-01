using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadingScreen : GameScreen
{
    #region Fields
    private const float loadingTime = 5f;
    [SerializeField] private UnityEvent onLoaded;
    [SerializeField] private Image fillLoadingBar;
    float timer;
    #endregion

    #region Core
    public override void Show()
    {
        base.Show();
        StartCoroutine(LoadingDelay());
    }

    private void Update()
    {
        timer += Time.deltaTime;
        SetFillImage(timer / loadingTime);
    }

    private IEnumerator LoadingDelay()
    {
        yield return new WaitForSeconds(loadingTime);
        onLoaded?.Invoke();
        Hide();
    }
    private void SetFillImage(float fillAmount)
    {
        fillLoadingBar.fillAmount = fillAmount;
    }
    #endregion
}
