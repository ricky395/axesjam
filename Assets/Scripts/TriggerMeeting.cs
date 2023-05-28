using UnityEngine;
using DG.Tweening;

public class TriggerMeeting : MonoBehaviour
{
    [SerializeField]
    private float valueAddOrDecrease;
    [SerializeField]
    private AudioClip clipOnTrigger;
    [SerializeField]
    private GameObject effectPrefab;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifeController.instance.ChangeLife(valueAddOrDecrease);

            if (clipOnTrigger != null)
                audioSource.PlayOneShot(clipOnTrigger);

            if (effectPrefab != null)
                Instantiate(effectPrefab, Vector3.zero, Quaternion.identity, transform.GetChild(0));

            Destroy(GetComponentInChildren<SpriteRenderer>());
            Destroy(GetComponent<BoxCollider>());

            Camera.main.DOShakePosition(0.3f, 1, 3, 30);
        }
    }
}
