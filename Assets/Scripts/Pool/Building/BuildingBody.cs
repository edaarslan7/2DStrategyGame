using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class BuildingBody : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject model;
    private Color correctColor;
    private Color wrongColor;
    private Material mainMat;
    private SpriteRenderer mainRenderer;
    #endregion

    #region Getters
    public SpriteRenderer MainRenderer => mainRenderer;
    #endregion

    #region Core
    public void Initialize(GameplayData gameplayData)
    {
        correctColor = gameplayData.CorrectPlaceColor;
        wrongColor = gameplayData.WorngPlaceColor;
        mainRenderer = model.GetComponent<SpriteRenderer>();
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
