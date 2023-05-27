using UnityEngine;

public class LevelMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;

    void Update()
    {
        Vector3 currentPos = transform.position;
        float newZPos = currentPos.z - speed * Time.deltaTime;
        Vector3 finalPos = new Vector3(currentPos.x, currentPos.y, newZPos);

        transform.SetPositionAndRotation(finalPos, Quaternion.identity);
    }
}
