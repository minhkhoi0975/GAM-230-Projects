/**
 * ButtonOnClick.cs
 * Programmer: Khoi Ho
 * Description: This script handles buttons in main menu.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIMainMenu : MonoBehaviour
{
    public void StartGame(string firstLevel)
    {
        GameManager.Instance.ResetPlayerStats();
        SceneManager.LoadScene(firstLevel);
    }

    public void HighScores(string highScoreScene)
    {
        SceneManager.LoadScene(highScoreScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
