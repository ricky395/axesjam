using UnityEngine;

public class DragMovement : MonoBehaviour
{
    [SerializeField]
    private float maxDragDistance;
    [SerializeField]
    private float moveForce;
    [SerializeField]
    private LayerMask tapLayer;
    [SerializeField]
    private LineRenderer helperLine;

    private Vector3 tapPoint = Vector3.zero;
    private Vector3 releasePoint = Vector3.zero;
    private Vector3 forceVector = Vector3.zero;

    private bool isHoldingTap = false;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TapPressed();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            TapReleased();
            ApplyForce();
        }

        if (isHoldingTap)
        {
            Debug.DrawRay(tapPoint, releasePoint, Color.red);
        }

        Debug.Log(isHoldingTap);
    }

    private void TapPressed()
    {
        isHoldingTap = true;
        GetHitPoint(ref tapPoint);
    }

    private void TapReleased()
    {
        isHoldingTap = false;
        GetHitPoint(ref releasePoint);
    }

    private void GetHitPoint(ref Vector3 hitPoint)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, tapLayer))
        {
            hitPoint = hit.point;
        }
    }

    private void ApplyForce()
    {
        forceVector = tapPoint - releasePoint;

        rb.AddForce(forceVector * moveForce, ForceMode.Impulse);
    }
}
