/**
 * MainMenuScript.cs
 * Description: This script handles the main menu.
 * Programmer: Khoi Ho
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Load the first scene.
    public void StartGame(string firstLevel)
    {
        // Reset the number of collected coins to 0.
        if(GameManagerScript.Instance!=null)
        {
            GameManagerScript.Instance.CoinsCollected = 0;
        }

        SceneManager.LoadScene(firstLevel);
    }

    // Exit the game.
    public void QuitGame()
    {
        Application.Quit();
    }
}
