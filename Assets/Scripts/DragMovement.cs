using System.Collections;
using UnityEngine;

public class DragMovement : MonoBehaviour
{
    [SerializeField]
    private float maxDragDistance;
    [SerializeField]
    private float moveForce;
    [SerializeField]
    private string tapLayer;
    [SerializeField]
    private LineRenderer helperLine;

    private Vector3 tapPoint = Vector3.zero;
    private Vector3 releasePoint = Vector3.zero;
    private Vector3 forceVector = Vector3.zero;

    private bool isHoldingTap = false;

    private Rigidbody rb;
    private WaitForSeconds wait;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        wait = new WaitForSeconds(0.5f);
        StartCoroutine(WakeRB());
    }

    private IEnumerator WakeRB()
    {
        for (; ; )
        {
            yield return wait;
            rb.WakeUp();
        }
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
        }

        if (isHoldingTap)
        {
            GetHitPoint(ref releasePoint);

            //Vector3 newTapPoint = new Vector3(tapPoint.x, tapPoint.y + 0.5f, tapPoint.z);
            //Vector3 newReleasePoint = new Vector3(releasePoint.x, releasePoint.y + 0.5f, releasePoint.z);
            //Vector3 normVector = (newReleasePoint - newTapPoint).normalized * maxDragDistance;
            //Debug.DrawRay(newReleasePoint, newTapPoint);

            //Vector3 newRelPoint = new Vector3(releasePoint.x, releasePoint.y + 0.5f, releasePoint.z);
            //Vector3 newVector = releasePoint - tapPoint;
            helperLine.SetPosition(1, new Vector3(releasePoint.x, releasePoint.y + 0.5f, releasePoint.z));
        }
    }

    private void TapPressed()
    {
        isHoldingTap = true;
        GetHitPoint(ref tapPoint);

        helperLine.enabled = true;
        Vector3 rayPoint = new Vector3(tapPoint.x, tapPoint.y + 0.5f, tapPoint.z);
        helperLine.SetPosition(0, rayPoint);
    }

    private void TapReleased()
    {
        isHoldingTap = false;
        GetHitPoint(ref releasePoint);

        helperLine.enabled = false;
        ApplyForce();
    }

    private void GetHitPoint(ref Vector3 hitPoint)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray.origin, ray.direction * 10);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            if (LayerMask.LayerToName(hit.collider.gameObject.layer).Equals(tapLayer))
            {
                hitPoint = hit.point;
                break;
            }
        }
    }

    private void ApplyForce()
    {
        forceVector = tapPoint - releasePoint;
        forceVector = forceVector.normalized * maxDragDistance;

        rb.AddForce(forceVector * moveForce, ForceMode.Impulse);
    }
}
