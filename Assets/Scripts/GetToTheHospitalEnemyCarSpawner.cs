using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;

public class GetToTheHospitalEnemyCarSpawner : MonoBehaviour
{
    public GameObject canvas;

    [SerializeField]
    private GameObject enemyCar;

    private double spawnTimer = 10f;

    private Vector3[] enemySpawnPoints =
    {
        new Vector3(0, 1.5f, 90),
        new Vector3(-8, 1.5f, 90),
        new Vector3(8, 1.5f, 90)
    };

    private Vector3 currentSpawnPoint;

    private bool canSpawn = true;

    public int score;

    
    void Awake()
    {
        canvas = GameObject.Find("Canvas");
        StartCoroutine(SpawnCars());
    }

    private IEnumerator SpawnCars()
    {
        WaitForSeconds wait = new WaitForSeconds((int)spawnTimer);
        while (canSpawn == true)
        {
            yield return wait;
            currentSpawnPoint = enemySpawnPoints[UnityEngine.Random.Range(0, enemySpawnPoints.Length)];
            Instantiate(enemyCar, currentSpawnPoint, Quaternion.identity);
            spawnTimer = spawnTimer / (Double)((score + 1) * 1.33);
            yield return wait;
        }
    }
}
