using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnums;

public static class CONSTANTS
{
    public static int COUNT = Enum.GetValues(typeof(StructureType)).Length;
    public const string placementPointTag = "PlacementPoint";
}
