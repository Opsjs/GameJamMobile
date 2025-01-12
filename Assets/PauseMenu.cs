using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject menuPause;
    bool isPaused;
    public string levelToLoad;


    void Start()
    {
        menuPause.SetActive(false);
    }


   public void Paused()
    {
        menuPause.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(levelToLoad);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
