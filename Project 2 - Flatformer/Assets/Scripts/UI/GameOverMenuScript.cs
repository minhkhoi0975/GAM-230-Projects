/**
 * GameCompletedMenuScript.cs
 * Description: This script handles the interface of the Game Over menu.
 * Programmer: Khoi Ho
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuScript : MonoBehaviour
{
    // Load the first level of the game.
    public void Retry(string firstLevelScene)
    {
        // Reset the number of collected coins to 0.
        if (GameManagerScript.Instance != null)
        {
            GameManagerScript.Instance.CoinsCollected = 0;
        }
        SceneManager.LoadScene(firstLevelScene);
    }

    // Go back to the main menu.
    public void GoToMainMenu(string mainMenuScene)
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
