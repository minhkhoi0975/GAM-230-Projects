using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIGameOver : MonoBehaviour
{
    public Text textScore; // Reference to the text showing the score.

    // Start is called before the first frame update
    void Start()
    {
        textScore.text = "Your score is: " + GameManager.Instance.totalScore;
    }

    public void Replay(string firstLevel)
    {
        GameManager.Instance.ResetPlayerStats();
        SceneManager.LoadScene(firstLevel);
    }

    public void MainMenu(string mainMenu)
    {
        SceneManager.LoadScene(mainMenu);
    }
}
