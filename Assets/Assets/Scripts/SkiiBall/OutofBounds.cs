using UnityEngine;

public class OutofBounds : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBall"))
        {
            Debug.Log("Out of Bounds");

            if (MaxTurns.Instance != null)
            {
                MaxTurns.Instance.ResolveThrow();
            }
        }
    }
}