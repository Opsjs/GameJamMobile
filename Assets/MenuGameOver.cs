using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    public GameObject menuGameOver;

    void Start()
    {
        menuGameOver.SetActive(false);
    }

    public void OnPlayerDeath()
    {
        menuGameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void MainMenuScene(string level)
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
