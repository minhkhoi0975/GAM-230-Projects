/**
 * GameCompletedMenuScript.cs
 * Description: This script handles the interface of the Game Completed Menu.
 * Programmer: Khoi Ho
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCompletedMenuScript : MonoBehaviour
{
    private void Start()
    {
        // Reference to the text that is used for displaying the number of collected coins.
        Text txtCoinsCollected = transform.GetChild(3).gameObject.GetComponent<Text>();

        // Display the number of collected coins.
        if(GameManagerScript.Instance!=null)
        {
            txtCoinsCollected.text = "You collected " + GameManagerScript.Instance.CoinsCollected + " coin(s).";
        }
    }

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
