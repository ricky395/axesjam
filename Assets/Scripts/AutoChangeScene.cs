using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoChangeScene : MonoBehaviour
{
    void Start()
    {
        SceneLoader.instance.LoadScene(1);
    }
}
