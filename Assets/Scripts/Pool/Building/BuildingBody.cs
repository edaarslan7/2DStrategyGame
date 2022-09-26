using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using static GameEnums;

public class BuildingBody : MonoBehaviour
{
    #region Fields
    [SerializeField] private List<SpriteRenderer> renderers;
    [SerializeField] private List<GameObject> physics;
    private SpriteRenderer mainRenderer;
    private Color correctColor;
    private Color wrongColor;
    private Material mainMat;
    #endregion

    #region Getters
    public SpriteRenderer MainRenderer => mainRenderer;
    #endregion

    #region Core
    public void Initialize(GameplayData gameplayData, StructureType type)
    {
        for (int i = 0; i < renderers.Count; i++)
        {
            if (i == (int)type)
            {
                SetChilds(i, true);
                mainRenderer = renderers[i];
            }
            else
                SetChilds(i, false);
        }
        correctColor = gameplayData.CorrectPlaceColor;
        wrongColor = gameplayData.WorngPlaceColor;
        mainMat = mainRenderer.material;
        MainRenderer.sortingOrder = 99;
    }

    private void SetChilds(int index, bool value)
    {
        renderers[index].gameObject.SetActive(value);
        physics[index].SetActive(value);
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
