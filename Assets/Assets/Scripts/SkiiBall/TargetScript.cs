using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private int score;

    [Header("Audio")]
    [SerializeField] private AudioClip targetHitSound;

    [Header("Particles")]
    [SerializeField] private ParticleSystem hitParticles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBall"))
        {
            Debug.Log("Target HIT!");

            // Add score
            if (TotalPoints.Instance != null)
            {
                TotalPoints.Instance.AddScore(score);
            }

            // Play sound
            if (targetHitSound != null)
            {
                AudioSource.PlayClipAtPoint(
                    targetHitSound,
                    transform.position
                );
            }

            // Play particles
            if (hitParticles != null)
            {
                hitParticles.transform.position = other.transform.position;
                hitParticles.Play();
            }
            else
            {
                Debug.LogWarning("Hit Particles is not assigned!");
            }

            // Finish this throw
            if (MaxTurns.Instance != null)
            {
                MaxTurns.Instance.ResolveThrow();
            }
        }
    }
}