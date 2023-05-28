using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private Image fadePanel;

    public static SceneLoader instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);

        instance = this;
    }

    public void LoadScene(int index, bool fade = false, float fadeTime = 0.01f)
    {
        if (fade)
        {
            StartCoroutine(LoadFading(index, fadeTime));
        }
        else
        {
            SceneManager.LoadScene(index);
        }
    }

    private IEnumerator LoadFading(int index, float fadeTime)
    {
        fadePanel.color = new Color(0, 0, 0, 0);
        fadePanel.DOFade(1, fadeTime);

        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene(index);
    }

    private void OnLevelWasLoaded(int level)
    {
        fadePanel.DOFade(0, 0.2f);
    }

    public int GetLevelsCount()
    {
        return SceneManager.sceneCountInBuildSettings;
    }
}
