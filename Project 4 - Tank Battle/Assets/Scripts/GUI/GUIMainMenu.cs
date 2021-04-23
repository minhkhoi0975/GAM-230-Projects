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
    public void StartGame(string sceneName)
    {
        GameManager.Instance.ResetPlayerStats();
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
