using UnityEngine;

public class PlayerBallLaunch : MonoBehaviour
{
    // I don't know wtf to do


    private float speed;
    private bool isLaunched = false;
    private int launchFactor;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Use mouse, click and drag the ball to show a trajectory 
        // Pull back to determine launch power
        // Release, ball propels forward!
        // ????
    }

    void ReleaseBall()
    {

    }

    void DragBall()
    {
        Debug.Log("Player has clicked and draging ball");

    }
}
