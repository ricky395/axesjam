using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    public bool debugLevel = false;
    [Range(4, 8)]
    public int debugFirstLevel = 4;

    public static bool hasWon = false;
    public static bool hasLost = false;

    private static int firstLevel = 4;
    public static int level = 4;

    private void Start()
    {
        if (debugLevel)
            level = debugFirstLevel;
    }

    public static void ResetProgress()
    {
        level = firstLevel;
    }

    private void OnLevelWasLoaded(int level)
    {
        hasWon = false;
        hasLost = false;
    }
}
