using UnityEngine;

public class GetToTheHospitalStartButton : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField]
    private GameObject playerCar;

    [SerializeField]
    private GameObject carSpawner;

    [SerializeField]
    private GameObject canvas;

    [Header("Scripts")]
    [SerializeField]
    private GetToTheHospitalEnemyCarSpawner carSpawnerScript;

    public void startGame()
    {
        // Enable gameplay
        playerCar.SetActive(true);
        carSpawner.SetActive(true);

        // Hide tutorial / start screen
        canvas.SetActive(false);

        // Reset score
        carSpawnerScript.score = 0;

        // Start the 60-second survival timer
        if (GameOverManager.Instance != null)
        {
            GameOverManager.Instance.StartGameTimer();
        }
        else
        {
            Debug.LogError("GameOverManager could not be found!");
        }
    }
}