using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaxTurns : MonoBehaviour
{
    public static MaxTurns Instance;

    [Header("Ball Limit")]
    [SerializeField] private int maxTurn = 7;
    [SerializeField] private int currentTurn = 0;

    [Header("UI")]
    [SerializeField] private TMP_Text turnCounterUI;
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text finalScoreText;

    private bool gameStarted = false;
    private bool gameEnded = false;
    private bool throwResolved = true;

    public bool CanLaunch =>
        gameStarted &&
        !gameEnded &&
        currentTurn < maxTurn &&
        throwResolved;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;

        currentTurn = 0;
        gameStarted = false;
        gameEnded = false;
        throwResolved = true;

        tutorialPanel.SetActive(true);
        gameOverPanel.SetActive(false);

        UpdateTurnUI();
    }

    // START BUTTON
    public void StartGame()
    {
        gameStarted = true;
        tutorialPanel.SetActive(false);

        if (TotalPoints.Instance != null)
        {
            TotalPoints.Instance.ResetScore();
        }

        UpdateTurnUI();
    }

    // Called when the player actually launches the ball
    public void RegisterThrow()
    {
        if (!CanLaunch)
            return;

        currentTurn++;
        throwResolved = false;

        UpdateTurnUI();
    }

    // Called after hitting a target OR going out of bounds
    public void ResolveThrow()
    {
        if (throwResolved || gameEnded)
            return;

        throwResolved = true;

        // Seven balls used
        if (currentTurn >= maxTurn)
        {
            GameOver();
        }
        else
        {
            BallResetPosition.Instance.ResetBall();
        }
    }

    private void UpdateTurnUI()
    {
        if (turnCounterUI != null)
        {
            turnCounterUI.text =
                "BALLS: " + currentTurn + " / " + maxTurn;
        }
    }

    private void GameOver()
    {
        gameEnded = true;

        if (finalScoreText != null && TotalPoints.Instance != null)
        {
            finalScoreText.text =
                "FINAL SCORE: " + TotalPoints.Instance.totalpoint;
        }

        gameOverPanel.SetActive(true);

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
