using UnityEngine;
using DG.Tweening;

public class BounceAnim : MonoBehaviour
{
    private RectTransform rectTransform;
    public float speed = 10f;
    public float maxValue = 50f;
    public Ease animCurve;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 currentPosition = rectTransform.anchoredPosition;
        currentPosition.y += speed * Time.deltaTime;
        rectTransform.anchoredPosition = currentPosition;

        rectTransform.DOAnchorPosY(maxValue, 1000).SetLoops(-1, LoopType.Yoyo).SetEase(animCurve);
    }
}
