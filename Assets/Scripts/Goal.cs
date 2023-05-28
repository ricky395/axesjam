using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GlobalVars.level++;
            SceneLoader.instance.LoadScene(2, true, 1);
        }
    }
}
