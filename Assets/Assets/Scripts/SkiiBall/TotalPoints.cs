using TMPro;
using UnityEngine;

public class TotalPoints : MonoBehaviour
{
    public static TotalPoints Instance;
    public int totalpoint = 0;
    [SerializeField] private TMP_Text scoreText;
    public MaxTurns maxTurns;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalpoint=0;
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
            
        }
        Instance = this;
         if (scoreText != null)
        {
            scoreText.text = $"Score: {totalpoint}";
        }

        DontDestroyOnLoad(gameObject); 
    }
    public void AddScore(int value)
    {
        totalpoint+=value;
        if (scoreText != null)
        {
            scoreText.text = $"Score: {totalpoint}";
            maxTurns.TriggerTurn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
