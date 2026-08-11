using UnityEngine;

public class JumpingGameStartButton : MonoBehaviour
{
    [SerializeField]
    private GameObject playerCharacter;

    [SerializeField]
    private GameObject platformSpawner;

    [SerializeField]
    private JumpingGamePlatformSpawnerScript platformSpawnerScript;

    [SerializeField]
    private GameObject canvas;

    public void startGame()
    {
        playerCharacter.SetActive(true);
        platformSpawner.SetActive(true);
        canvas.SetActive(false);
        platformSpawnerScript.score = 0;
    }
}
