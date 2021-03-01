using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame(string firstLevel)
    {
        if(GameManagerScript.Instance!=null)
        {
            GameManagerScript.Instance.CoinsCollected = 0;
        }

        SceneManager.LoadScene(firstLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
