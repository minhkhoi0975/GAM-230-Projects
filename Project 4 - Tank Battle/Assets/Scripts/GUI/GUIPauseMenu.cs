using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIPauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = pauseMenu.activeSelf ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Restart()
    {
        GameManager.Instance.currentLevelScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu(string mainMenuScene)
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
