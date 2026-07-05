using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;

public class GetToTheHospitalEnemyCarSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyCar;
    public float spawnTimer = 200f;
    private Vector3[] enemySpawnPoints =
    {
        new Vector3(0, 1.5f, 90),
        new Vector3(-8, 1.5f, 90),
        new Vector3(8, 1.5f, 90)
    };


    private Vector3 currentSpawnPoint;

    private bool canSpawn = true;

    
    void Start()
    {
        StartCoroutine(SpawnCars());
    }

    private IEnumerator SpawnCars()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnTimer);
        while (canSpawn == true)
        {
            yield return wait;
            currentSpawnPoint = enemySpawnPoints[UnityEngine.Random.Range(0, enemySpawnPoints.Length)];
            Instantiate(enemyCar, currentSpawnPoint, Quaternion.identity);
            yield return wait;
        }
    }
}
