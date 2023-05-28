using UnityEngine;

public class TriggerBooster : MonoBehaviour
{
    [SerializeField]
    private float valueAddOrDecrease;

    [SerializeField]
    private AudioClip clipOnTrigger;

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

            Destroy(GetComponentInChildren<SpriteRenderer>());
            Destroy(GetComponentInChildren<BoxCollider>());
        }
    }
}
