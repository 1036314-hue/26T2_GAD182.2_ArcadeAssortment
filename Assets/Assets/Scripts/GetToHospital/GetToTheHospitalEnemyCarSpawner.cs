using System.Collections;
using UnityEngine;

public class GetToTheHospitalEnemyCarSpawner : MonoBehaviour
{
    public GameObject canvas;

    [Header("Enemy Car")]
    [SerializeField]
    private GameObject enemyCar;

    [Header("Enemy Speed")]
    [SerializeField]
    private float startingEnemySpeed = 30f;

    [SerializeField]
    private float speedIncreasePerPoint = 5f;

    [SerializeField]
    private float maxEnemySpeed = 100f;

    [Header("Spawn Speed")]
    [SerializeField]
    private float startingSpawnInterval = 2f;

    [SerializeField]
    private float spawnDecreasePerPoint = 0.05f;

    [SerializeField]
    private float minimumSpawnInterval = 0.7f;

    private Vector3[] enemySpawnPoints =
    {
        new Vector3(0, 1.5f, 90),
        new Vector3(-8, 1.5f, 90),
        new Vector3(8, 1.5f, 90)
    };

    public int score = 0;

    // Enemy cars get faster as score increases
    public float EnemySpeed
    {
        get
        {
            return Mathf.Min(
                startingEnemySpeed + score * speedIncreasePerPoint,
                maxEnemySpeed
            );
        }
    }

    // Enemy cars spawn more frequently as score increases
    private float CurrentSpawnInterval
    {
        get
        {
            return Mathf.Max(
                startingSpawnInterval - score * spawnDecreasePerPoint,
                minimumSpawnInterval
            );
        }
    }

    void Awake()
    {
        canvas = GameObject.Find("Canvas");
    }

    void OnEnable()
    {
        StartCoroutine(SpawnCars());
    }

    private IEnumerator SpawnCars()
    {
        while (true)
        {
            // Wait based on current score
            yield return new WaitForSeconds(CurrentSpawnInterval);

            // Pick one of the three lanes randomly
            Vector3 spawnPoint =
                enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)];

            // Spawn enemy car
            Instantiate(enemyCar, spawnPoint, Quaternion.identity);
        }
    }
}