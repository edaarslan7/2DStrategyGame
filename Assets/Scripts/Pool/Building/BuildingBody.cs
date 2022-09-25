using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class BuildingBody : MonoBehaviour
{
    #region Fields
    [SerializeField] private SpriteRenderer mainRenderer;
    private Color correctColor;
    private Color wrongColor;
    private Material mainMat;
    #endregion

    #region Getters
    public SpriteRenderer MainRenderer => mainRenderer;
    #endregion

    #region Core
    public void Initialize(GameplayData gameplayData)
    {
        correctColor = gameplayData.CorrectPlaceColor;
        wrongColor = gameplayData.WorngPlaceColor;
        mainMat = mainRenderer.material;
    }
    #endregion

    #region Color
    public void ColorChangings(bool correctPoint)
    {
        mainMat.color = correctPoint == true ? correctColor : wrongColor;
    }

    public void ResetColor()
    {
        mainMat.color = Color.white;
    }
    #endregion

}
