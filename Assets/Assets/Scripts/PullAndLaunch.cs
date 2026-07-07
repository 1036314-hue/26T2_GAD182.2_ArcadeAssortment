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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        unityCamera = Camera.main;

        // Stops gravity from taking over before the launch
        rb.isKinematic = true;
    }

    void OnMouseDown()
    {
        isDragging = true;
        startPos = transform.position;
        rb.isKinematic = true;
        rb.linearVelocity = Vector3.zero;

        // Creates an invisible flat horizontal plane at the ball's height for dragging
        movementPlane = new Plane(Vector3.up, startPos);
    }

    void OnMouseDrag()
    {
        if (!isDragging) return;

        // Shoot a ray from the camera through the mouse pointer
        Ray ray = unityCamera.ScreenPointToRay(Input.mousePosition);

        // Find where the ray intersects our invisible horizontal plane
        if (movementPlane.Raycast(ray, out float entry))
        {
            Vector3 mouseWorldPos = ray.GetPoint(entry);

            // Calculate pull distance on X and Z axes
            Vector3 currentDrag = mouseWorldPos - startPos;

            if (currentDrag.magnitude > maxDrag)
            {
                currentDrag = currentDrag.normalized * maxDrag;
            }

            // Visually move the ball back as you drag
            transform.position = startPos + currentDrag;
        }
    }

    void OnMouseUp()
    {
        if (!isDragging) return;
        isDragging = false;

        // Force vector points in the opposite direction of the pull
        Vector3 currentPos = transform.position;
        Vector3 launchDirection = startPos - currentPos;

        rb.isKinematic = false;

        // Applies a sudden, explosive physical force
        rb.AddForce(launchDirection * launchForce, ForceMode.Impulse);
    }
}

