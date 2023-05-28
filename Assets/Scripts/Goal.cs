using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !GlobalVars.hasLost)
        {
            GlobalVars.hasWon = true;
            GlobalVars.level++;
            SceneLoader.instance.LoadScene(2, true, 1);
        }
    }
}
