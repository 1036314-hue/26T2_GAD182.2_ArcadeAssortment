using UnityEngine;
using TMPro;

public class GetToTheHospitalScoreUI : MonoBehaviour
{
    [Header("Score")]
    [SerializeField]
    private GetToTheHospitalEnemyCarSpawner carSpawner;

    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private int pointsPerCar = 1000;

    private void Start()
    {
        UpdateScore();
    }

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        if (carSpawner == null || scoreText == null)
            return;

        int displayedScore = carSpawner.score * pointsPerCar;

        scoreText.text = "SCORE: " + displayedScore;
    }
}
