using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMap : MonoBehaviour
{
    public void Load()
    {
        SceneLoader.LoadScene(GlobalVars.level);
    }
}
