using UnityEngine;

public class OutofBounds : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerBall"))
        {
            Debug.Log("Out of Bounds");
        
            BallResetPosition.Instance.ResetBall();
        }
      
    }
}
