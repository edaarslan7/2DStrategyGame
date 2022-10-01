using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlaceAnim : MonoBehaviour
{
    [SerializeField] private Animator clickAC;
    public void ClickAnim(Vector2 pos)
    {
        transform.position = pos;
        clickAC.SetBool("Click", true);
    }
    public void ResetClick()
    {
        clickAC.SetBool("Click", false);
        gameObject.SetActive(false);
    }
}
