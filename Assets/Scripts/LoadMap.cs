using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMap : MonoBehaviour
{
    public void LoadPreMap()
    {
        SceneLoader.instance.LoadScene(4);
    }

    public void Load()
    {
        SceneLoader.instance.LoadScene(GlobalVars.level);
    }

    public void BackToMenu()
    {
        SceneLoader.instance.LoadScene(1);
    }
}
