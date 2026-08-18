using UnityEngine;

public class BallResetPosition : MonoBehaviour
{
    public static BallResetPosition Instance;

    [SerializeField]
    private PullAndLaunch playerBall;

    [SerializeField]
    private Transform ballPosition;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        // Press Space to manually reset the ball
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (MaxTurns.Instance != null)
            {
                MaxTurns.Instance.ResolveThrow();
            }
            else
            {
                ResetBall();
            }
        }
    }

    public void ResetBall()
    {
        playerBall.transform.position = ballPosition.position;
        playerBall.ResetPhysics();
    }
}