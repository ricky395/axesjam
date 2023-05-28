using UnityEngine;

public class TriggerBooster : MonoBehaviour
{
    [SerializeField]
    private float valueAddOrDecrease;

    [SerializeField]
    private AudioClip clipOnTrigger;

    private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifeController.instance.ChangeLife(valueAddOrDecrease);
            Destroy(this.gameObject);
        }
    }
}
