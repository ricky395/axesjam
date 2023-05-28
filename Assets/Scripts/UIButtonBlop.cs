using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Button))]
public class UIButtonBlop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("Leave empty for itself")]
    [SerializeField] RectTransform tweenTarget;
    [SerializeField] float targetScaleValue = 0.95f;

    private Button btn;

    private Tween tIn;
    private Tween tOut;

    private Vector3 orgScale;

    void Awake()
    {
        btn = GetComponent<Button>();
        if (tweenTarget == null) tweenTarget = GetComponent<RectTransform>();
        orgScale = tweenTarget.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            if (tOut != null && tOut.IsActive() && tOut.IsPlaying())
            {
                tOut.Kill();
            }
            tIn = tweenTarget.DOScale(orgScale * targetScaleValue, 0.1f).SetEase(Ease.Linear).Play();  // <- Fer here
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (tIn != null && tIn.IsActive() && tIn.IsPlaying())
        {
            tIn.Kill();
        }
        tOut = tweenTarget.DOScale(orgScale, 0.1f).SetEase(Ease.Linear).Play(); // <- Fer here
    }
}
