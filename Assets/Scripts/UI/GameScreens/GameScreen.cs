using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class GameScreen : MonoBehaviour
{
    #region Fields
    [SerializeField] protected GameObject screen;
    [SerializeField] protected Animator animator;

    [SerializeField] private string showClipName = "Intro";
    [SerializeField] private string hideClipName = "Outro";
    #endregion

    #region Core
    public virtual void Show()
    {
        if (ReferenceEquals(animator.runtimeAnimatorController, null))
        {
            screen.SetActive(true);
        }
        else
        {
            animator.Play(showClipName);
        }
    }

    public virtual void Hide()
    {
        if (screen.activeInHierarchy)
        {
            if (ReferenceEquals(animator.runtimeAnimatorController, null))
            {
                screen.SetActive(false);
            }
            else
            {
                animator.Play(hideClipName);
            }
        }
    }
    #endregion
}
