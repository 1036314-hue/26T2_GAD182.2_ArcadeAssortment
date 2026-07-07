using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    private float offset = -0.8f;
    private Vector3 temporaryPosition;


    void Start()
    {
        transform.position = new Vector3 (transform.position.x, transform.position.y, offset);
    }

    void Update()
    {
        temporaryPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        transform.position = new Vector3(temporaryPosition.x, temporaryPosition.y, offset);

    }
}
