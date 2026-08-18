using UnityEngine;

public class SkillCheckStartButton : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorialPanel;

    [SerializeField]
    private SkillCheckManager skillCheckManager;

    [SerializeField]
    private SkillCheckInputs skillCheckInputs;

    private void Awake()
    {
        skillCheckManager.enabled = false;
        skillCheckInputs.enabled = false;

        tutorialPanel.SetActive(true);
    }

    public void StartGame()
    {
        tutorialPanel.SetActive(false);

        skillCheckManager.enabled = true;
        skillCheckInputs.enabled = true;
    }
}