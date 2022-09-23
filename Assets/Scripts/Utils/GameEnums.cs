using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEnums
{
    public enum GameStates
    {
        Loading=1,
        GamePlay=2,
        GameEnd=3
    }

    public enum ScreenTags
    {
        LoadingScreen,
        GamePlayScreen,
        GameEndScreen,
    }

    public enum PlacementPointState
    {
        Empty = 1,
        Full = 2,
    }

    public enum StructureType
    {
        Building=0,
        PowerPlant=1,
        Barrack=2
    }
}
