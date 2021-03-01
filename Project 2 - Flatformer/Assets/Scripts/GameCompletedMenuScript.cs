using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCompletedMenuScript : MonoBehaviour
{
    private void Start()
    {
        Text txtCoinsCollected = transform.GetChild(3).gameObject.GetComponent<Text>();

        if(GameManagerScript.Instance!=null)
        {
            txtCoinsCollected.text = "You collected " + GameManagerScript.Instance.CoinsCollected + " coin(s).";
        }
    }

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
