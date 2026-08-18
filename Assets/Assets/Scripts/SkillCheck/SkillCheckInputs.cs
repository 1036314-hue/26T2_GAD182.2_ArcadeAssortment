using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SkillCheckInputs : MonoBehaviour
{
    [Header("Manager")]
    public SkillCheckManager manager;

    [Header("Game Objects")]
    public GameObject arrow;
    public GameObject bar;

    [Header("Bar Settings")]
    public float barLeftLimit = -10f;
    public float barRightLimit = 120f;

    [Header("Score and Health")]
    public float score = 0f;
    public float health = 5f;

    [Header("Bar Random Position")]
    public float barRandomLeftLimit = -800f;
    public float barRandomRightLimit = 700f;

    [Header("Audio")]
    [SerializeField]
    private AudioClip hitSound;

    [SerializeField]
    private AudioClip missSound;

    [Header("Game Over")]
    [SerializeField]
    private GameObject gameOverPanel;

    private bool gameEnded = false;

    private void Start()
    {
        Time.timeScale = 1f;

        gameEnded = false;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (gameEnded)
            return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            float arrowPositionComparedToBar =
                arrow.transform.localPosition.x -
                bar.transform.localPosition.x;

            Debug.Log(
                "Position actually checked: " +
                arrowPositionComparedToBar
            );

            // HIT
            if (arrowPositionComparedToBar >= barLeftLimit &&
                arrowPositionComparedToBar <= barRightLimit)
            {
                score += 1;

                Debug.Log(
                    "Hit! Your score is now " + score
                );

                // Play hit sound
                if (hitSound != null)
                {
                    Vector3 soundPosition =
                        Camera.main != null
                        ? Camera.main.transform.position
                        : Vector3.zero;

                    AudioSource.PlayClipAtPoint(
                        hitSound,
                        soundPosition
                    );
                }

                // Increase difficulty
                manager.arrowSpeed += 175;
            }

            // MISS
            else
            {
                health -= 1;

                Debug.Log(
                    "Miss! You now have " +
                    health +
                    " Health"
                );

                // Play miss sound
                if (missSound != null)
                {
                    Vector3 soundPosition =
                        Camera.main != null
                        ? Camera.main.transform.position
                        : Vector3.zero;

                    AudioSource.PlayClipAtPoint(
                        missSound,
                        soundPosition
                    );
                }

                // No health left
                if (health <= 0)
                {
                    GameOver();
                    return;
                }
            }

            // Move target bar to a random location
            Vector3 newBarPosition =
                bar.transform.localPosition;

            newBarPosition.x = Random.Range(
                barRandomLeftLimit,
                barRandomRightLimit
            );

            bar.transform.localPosition =
                newBarPosition;
        }
    }

    private void GameOver()
    {
        if (gameEnded)
            return;

        gameEnded = true;

        Debug.Log("GAME OVER");

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ReplayGame()
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