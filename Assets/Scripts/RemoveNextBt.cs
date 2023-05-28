using UnityEngine;

public class RemoveNextBt : MonoBehaviour
{
    void Start()
    {
        if (GlobalVars.level > SceneLoader.instance.GetLevelsCount())
        {
            GlobalVars.ResetProgress();
            Destroy(this.gameObject);
        }
    } 
}
