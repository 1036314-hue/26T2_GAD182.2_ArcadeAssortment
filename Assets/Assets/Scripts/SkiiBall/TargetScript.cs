using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField] private int score;

   
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerBall"))
        {
            Debug.Log("Target HIT!");
            TotalPoints.Instance.AddScore(score);
            BallResetPosition.Instance.ResetBall();
        }
      
    }
}
