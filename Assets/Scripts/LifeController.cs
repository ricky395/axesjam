using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    [SerializeField]
    public float totalTime;
    private float time;

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

    public static LifeController instance;

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
            fgFeedback.fillAmount = fgReal.fillAmount + fillVal;

            time += fgFeedback.fillAmount;
        }
        else if (value < 0)
        {
            fillVal = value / totalTime;

            fgFeedback.color = badFeedback;
            fgFeedback.fillAmount = fgReal.fillAmount;

            time += fillVal;
        }
    }
}
