using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{
    public float speed = 2;
    public bool reverse;

    private RectTransform rt;

    void Start()
    {
        speed = reverse ? -speed : speed;
        rt = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rt.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}
