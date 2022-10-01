using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Gameplay Data", menuName = "2DStrategyGame/Gameplay Data")]
public class GameplayData : ScriptableObject
{
    #region Fields
    [Header("Color Settings")]
    [SerializeField] private Color correctPlaceColor;
    [SerializeField] private Color worngPlaceColor;

    [Header("Sprite List")]
    [SerializeField] private List<Sprite> buildings;
    [SerializeField] private List<Sprite> powerPlants;
    [SerializeField] private List<Sprite> barracks;
    [SerializeField] private List<Sprite> soldiers;

    [Header("Building Data")]
    [SerializeField] private List<Vector2> scales;
    #endregion

    #region Getters
    public Color CorrectPlaceColor => correctPlaceColor;
    public Color WorngPlaceColor => worngPlaceColor;
    public List<Sprite> Buildings => buildings;
    public List<Sprite> PowerPlants => powerPlants;
    public List<Sprite> Barracks => barracks;
    public List<Sprite> Soldiers => soldiers;
    public List<Vector2> Scales => scales;
    #endregion
}
