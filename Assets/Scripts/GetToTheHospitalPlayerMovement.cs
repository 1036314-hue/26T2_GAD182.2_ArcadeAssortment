using UnityEngine;
using UnityEngine.InputSystem;

public class GetToTheHospitalPlayerMovement : MonoBehaviour
{
    private bool isLeft;

    private bool isRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            MoveLeft();
        }
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            MoveRight();
        }
    }

    private void MoveLeft()
    {
        if (!isLeft && !isRight)
        {
            transform.position -= Vector3.right * 8;
            isLeft = true;
        }
        else if (!isLeft && isRight)
        {
            transform.position -= Vector3.right * 8;
            isRight = false;
        }
    }

    private void MoveRight()
    {
        if (!isLeft && !isRight)
        {
            transform.position += Vector3.right * 8;
            isRight = true;
        }
        else if (isLeft && !isRight)
        {
            transform.position += Vector3.right * 8;
            isLeft = false;
        }
    }
}
