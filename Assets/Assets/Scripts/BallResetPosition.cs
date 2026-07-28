using UnityEngine;

public class BallResetPosition : MonoBehaviour
{
    GameObject PlayerBall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Move ball back to starting position
            // transform.position = PlayerBall.(0, 1.68, -8);
        }
    }
}
