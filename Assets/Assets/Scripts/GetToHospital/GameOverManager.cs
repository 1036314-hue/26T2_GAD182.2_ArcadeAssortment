using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;

    [Header("Lose UI")]
    [SerializeField] private GameObject gameOverPanel;

    [Header("Win UI")]
    [SerializeField] private GameObject winPanel;

    [Header("Timer")]
    [SerializeField] private float gameTime = 60f;
    [SerializeField] private TMP_Text timerText;

    private bool gameEnded = false;
    private bool timerStarted = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;

        gameEnded = false;
        timerStarted = false;

        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);

        UpdateTimerUI(gameTime);
    }

    public void StartGameTimer()
    {
        if (timerStarted)
            return;

        timerStarted = true;
        StartCoroutine(GameTimer());
    }

    private IEnumerator GameTimer()
    {
        float remaining = gameTime;

        while (remaining > 0 && !gameEnded)
        {
            remaining -= Time.deltaTime;

            if (remaining < 0)
                remaining = 0;

            UpdateTimerUI(remaining);

            yield return null;
        }

        if (!gameEnded)
        {
            WinGame();
        }
    }

    private void UpdateTimerUI(float remaining)
    {
        if (timerText == null)
            return;

        int seconds = Mathf.CeilToInt(remaining);

        timerText.text = "TIME: " + seconds;

        float percentage = remaining / gameTime;

        if (percentage <= 0.2f)
        {
            timerText.color = Color.red;
        }
        else if (percentage <= 0.5f)
        {
            timerText.color = Color.yellow;
        }
        else
        {
            timerText.color = Color.green;
        }
    }

    public void GameOver()
    {
        if (gameEnded)
            return;

        gameEnded = true;

        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void WinGame()
    {
        if (gameEnded)
            return;

        gameEnded = true;

        winPanel.SetActive(true);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}