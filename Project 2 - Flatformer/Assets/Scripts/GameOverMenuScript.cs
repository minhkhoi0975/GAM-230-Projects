using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuScript : MonoBehaviour
{
    public void Retry(string firstLevelScene)
    {
        if (GameManagerScript.Instance != null)
        {
            GameManagerScript.Instance.CoinsCollected = 0;
        }
        SceneManager.LoadScene(firstLevelScene);
    }

    public void GoToMainMenu(string mainMenuScene)
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
