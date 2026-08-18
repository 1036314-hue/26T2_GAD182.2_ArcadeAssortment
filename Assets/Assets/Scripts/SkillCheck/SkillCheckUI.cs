using UnityEngine;
using TMPro;

public class SkillCheckUI : MonoBehaviour
{
    public SkillCheckInputs skillCheckInputs;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    void Update()
    {

        //updating UI
        healthText.text = "Health: " + skillCheckInputs.health + "!";
        scoreText.text = "Score: " + skillCheckInputs.score + "!";
    }
}
