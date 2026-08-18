using UnityEngine;

public class GetToTheHospitalEnemyCar : MonoBehaviour
{
    public GameObject spawner;

    [Header("Spawner")]
    [SerializeField]
    private GetToTheHospitalEnemyCarSpawner spawnerScript;

    [Header("Audio")]
    [SerializeField]
    private AudioClip scoreClip;

    [SerializeField]
    private AudioClip crashSound;

    [Header("Crash Effect")]
    [SerializeField]
    private GameObject crashEffect;

    private void Start()
    {
        // Find the car spawner
        spawner = GameObject.Find("CarSpawner");

        if (spawner != null)
        {
            spawnerScript =
                spawner.GetComponent<GetToTheHospitalEnemyCarSpawner>();
        }
    }

    private void Update()
    {
        if (spawnerScript == null)
            return;

        // Move enemy car towards the player
        transform.position +=
            -transform.forward *
            Time.deltaTime *
            spawnerScript.EnemySpeed;

        // Player successfully dodged the car
        if (transform.position.z <= -13)
        {
            spawnerScript.score += 1;

            // Play score sound
            if (scoreClip != null)
            {
                AudioSource.PlayClipAtPoint(
                    scoreClip,
                    transform.position
                );
            }

            Debug.Log("Score: " + spawnerScript.score);

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player Car")
        {
            // Use the actual collision point
            Vector3 crashPosition = transform.position;

            if (collision.contactCount > 0)
            {
                crashPosition = collision.GetContact(0).point;
            }

            // Play crash sound
            if (crashSound != null)
            {
                AudioSource.PlayClipAtPoint(
                    crashSound,
                    crashPosition
                );
            }

            // Spawn crash particles
            if (crashEffect != null)
            {
                GameObject effect = Instantiate(
                    crashEffect,
                    crashPosition,
                    Quaternion.identity
                );

                ParticleSystem particle =
                    effect.GetComponent<ParticleSystem>();

                if (particle != null)
                {
                    var main = particle.main;

                    // Keep particles playing when timeScale becomes 0
                    main.useUnscaledTime = true;

                    // Destroy particle object automatically
                    // when the particle system finishes
                    main.stopAction =
                        ParticleSystemStopAction.Destroy;
                }
            }

            // Trigger Game Over
            if (GameOverManager.Instance != null)
            {
                GameOverManager.Instance.GameOver();
            }
            else
            {
                Debug.LogError(
                    "GameOverManager could not be found!"
                );
            }
        }
    }
}