using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame1()
    {
        SceneManager.LoadScene("NeonDodgeArena");
    }

    public void PlayGame2()
    {
        SceneManager.LoadScene("GetToTheHospital");
    }

    public void PlayGame3()
    {
        SceneManager.LoadScene("SkiiBall");
    }

    public void PlayGame4()
    {
        SceneManager.LoadScene("SkillCheck");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credits");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}