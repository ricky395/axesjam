using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    private static int firstLevel = 4;
    public static int level = 4;

    public static void ResetProgress()
    {
        level = firstLevel;
    }
}
