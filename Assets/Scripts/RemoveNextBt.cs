using UnityEngine;

public class RemoveNextBt : MonoBehaviour
{
    void Start()
    {
        if (GlobalVars.level + 1 > SceneLoader.instance.GetLevelsCount())
        {
            GlobalVars.ResetProgress();
            Destroy(GetComponent<UIButtonBlop>());
            Destroy(this.gameObject);
        }
    } 
}
