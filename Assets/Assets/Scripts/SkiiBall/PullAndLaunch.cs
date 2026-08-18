using UnityEngine;

public class PullAndLaunch : MonoBehaviour
{
    [Header("Launcher Settings")]
    public float launchForce = 15f;
    public float maxDrag = 5f;

    private Rigidbody rb;
    private Camera unityCamera;
    private Vector3 startPos;

    private bool isDragging = false;
    private Plane movementPlane;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        unityCamera = Camera.main;

        rb.isKinematic = true;
    }

    private void OnMouseDown()
    {
        // Don't allow another launch unless the game permits it
        if (MaxTurns.Instance != null &&
            !MaxTurns.Instance.CanLaunch)
        {
            return;
        }

        isDragging = true;
        startPos = transform.position;

        rb.isKinematic = true;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        movementPlane = new Plane(Vector3.up, startPos);
    }

    private void OnMouseDrag()
    {
        if (!isDragging)
            return;

        Ray ray =
            unityCamera.ScreenPointToRay(Input.mousePosition);

        if (movementPlane.Raycast(ray, out float entry))
        {
            Vector3 mouseWorldPos =
                ray.GetPoint(entry);

            Vector3 currentDrag =
                mouseWorldPos - startPos;

            if (currentDrag.magnitude > maxDrag)
            {
                currentDrag =
                    currentDrag.normalized * maxDrag;
            }

            transform.position =
                startPos + currentDrag;
        }
    }

    private void OnMouseUp()
    {
        if (!isDragging)
            return;

        isDragging = false;

        Vector3 currentPos = transform.position;

        Vector3 launchDirection =
            startPos - currentPos;

        // Count this ball
        if (MaxTurns.Instance != null)
        {
            MaxTurns.Instance.RegisterThrow();
        }

        rb.isKinematic = false;

        rb.AddForce(
            launchDirection * launchForce,
            ForceMode.Impulse
        );
    }

    public void ResetPhysics()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.ResetInertiaTensor();

        // Hold ball still until next launch
        rb.isKinematic = true;
    }
}