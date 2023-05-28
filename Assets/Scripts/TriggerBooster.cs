using UnityEngine;

public class TriggerBooster : MonoBehaviour
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

            Instantiate(effectPrefab, Vector3.zero, Quaternion.identity, transform.GetChild(0));
            Destroy(GetComponentInChildren<SpriteRenderer>());
            Destroy(GetComponent<BoxCollider>());
        }
    }
}
