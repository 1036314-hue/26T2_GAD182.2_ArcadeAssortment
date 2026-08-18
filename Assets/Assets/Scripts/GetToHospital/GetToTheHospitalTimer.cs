using System.Collections;
using UnityEngine;
using TMPro;

public class GetToTheHospitalTimer : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField]
    private float gameTime = 60f;

    [SerializeField]
    private TMP_Text gameTimer;

    [Header("Game Objects")]
    [SerializeField]
    private GameObject playerCar;

    [SerializeField]
    private GameObject carSpawner;

    [SerializeField]
    private GameObject gameOverCanvas;

    private Coroutine timerCoroutine;

    public void StartTimer()
    {
        // Prevent two timers running at the same time
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }

        timerCoroutine = StartCoroutine(GameTimer());
    }

    private IEnumerator GameTimer()
    {
        float remaining = gameTime;

        while (remaining > 0)
        {
            remaining -= Time.deltaTime;

            if (remaining < 0)
            {
                remaining = 0;
            }

            int totalSeconds = Mathf.CeilToInt(remaining);

            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int seconds = totalSeconds % 60;

            gameTimer.text =
                $"{hours:D2}:{minutes:D2}:{seconds:D2}";

            float percentage = remaining / gameTime;

            if (percentage <= 0.2f)
            {
                gameTimer.color = Color.red;
            }
            else if (percentage <= 0.5f)
            {
                gameTimer.color = Color.yellow;
            }
            else
            {
                gameTimer.color = Color.green;
            }

            yield return null;
        }

        gameTimer.text = "00:00:00";
        gameTimer.color = Color.red;

        EndGame();
    }

    private void EndGame()
    {
        // Stop player
        if (playerCar != null)
        {
            playerCar.SetActive(false);
        }

        // Stop new enemy cars spawning
        if (carSpawner != null)
        {
            carSpawner.SetActive(false);
        }

        // Show Game Over screen
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }

        timerCoroutine = null;
    }
}