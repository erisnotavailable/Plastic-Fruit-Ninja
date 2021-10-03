using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars
{
    public enum FruitType
    {
        Watermelon,
        Apple,
        Avocado,
        Strawberry,
        DragonFruit
    };

    public static GUIStyle style = new GUIStyle() {
        fontSize = 32
    };
}