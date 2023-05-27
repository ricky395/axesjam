using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    
    public static void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public static void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
