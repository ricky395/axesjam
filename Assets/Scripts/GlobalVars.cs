using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    public bool debugLevel = false;
    [Range(4, 10)]
    public int debugFirstLevel = 4; 

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
}
