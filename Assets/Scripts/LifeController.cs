using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    [SerializeField]
    public float totalTime;

    [SerializeField]
    private Image bg;
    [SerializeField]
    private Image fgFeedback;
    [SerializeField]
    private Image fgReal;

    [SerializeField]
    private Color goodFeedback;
    [SerializeField]
    private Color badFeedback;

    [SerializeField]
    private GameObject addSprite;
    [SerializeField]
    private GameObject substractSprite;

    public static LifeController instance;

    private float time;
    private bool alreadyLost = false;

    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);

        instance = this;
    }

    private void Start()
    {
        time = totalTime;
    }

    private void Update()
    {
        time -= Time.deltaTime * 0.3f;

        if (time <= 0 && !alreadyLost && !GlobalVars.hasWon)
        {
            alreadyLost = true;
            GlobalVars.hasLost = true;
            SceneLoader.instance.LoadScene(3, true, 0.6f);
        }

        float lerpVal = time / totalTime;
        fgReal.fillAmount = Mathf.Lerp(0, 1, lerpVal);
    }

    public void ChangeLife(float value)
    {
        float fillVal;
        if (value > 0)
        {
            fillVal = value / totalTime;

            fgFeedback.color = goodFeedback;
            fgFeedback.fillAmount = fgReal.fillAmount;

            time += fgFeedback.fillAmount;

            addSprite.SetActive(true);
        }
        else if (value < 0)
        {
            fillVal = value / totalTime;

            fgFeedback.color = badFeedback;
            fgFeedback.fillAmount = fgReal.fillAmount;

            time += fillVal;

            substractSprite.SetActive(false);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        alreadyLost = false;

        time = FindObjectOfType<MapTime>().GetMapTime();
    }
}
