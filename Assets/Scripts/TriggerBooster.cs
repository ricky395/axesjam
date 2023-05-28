using UnityEngine;

public class TriggerBooster : MonoBehaviour
{
    [SerializeField]
    private float valueAddOrDecrease;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifeController.instance.ChangeLife(valueAddOrDecrease);
            Destroy(this.gameObject);
        }
    }
}
