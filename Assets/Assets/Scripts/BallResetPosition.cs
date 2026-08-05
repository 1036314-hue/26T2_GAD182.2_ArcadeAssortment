using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BallResetPosition : MonoBehaviour
{
    public static BallResetPosition Instance;
    [SerializeField] 
    private PullAndLaunch PlayerBall;
    [SerializeField] private Transform ballPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
            
        }
        Instance = this;

        DontDestroyOnLoad(gameObject); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Move ball back to starting position
           ResetBall();
        }
    }
    public void ResetBall()
    {
        PlayerBall.transform.position=ballPosition.position;
        PlayerBall.ResetPhysics();
    }
}
