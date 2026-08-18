using TMPro;
using UnityEngine;

public class TotalPoints : MonoBehaviour
{
    public static TotalPoints Instance;

    public int totalpoint = 0;

    [SerializeField]
    private TMP_Text scoreText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ResetScore();
    }

    public void AddScore(int value)
    {
        totalpoint += value;
        UpdateScoreUI();
    }

    public void ResetScore()
    {
        totalpoint = 0;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text =
                "SCORE: " + totalpoint;
        }
    }
}