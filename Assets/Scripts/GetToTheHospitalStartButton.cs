using UnityEngine;

public class GetToTheHospitalStartButton : MonoBehaviour
{
    [SerializeField]
    private GameObject playerCar;

    [SerializeField]
    private GameObject carSpawner;

    [SerializeField]
    private GetToTheHospitalEnemyCarSpawner carSpawnerScript;

    [SerializeField]
    private GameObject canvas;

    public void startGame()
    {
        playerCar.SetActive(true);
        carSpawner.SetActive(true);
        canvas.SetActive(false);
        carSpawnerScript.score = 0;
    }
}
