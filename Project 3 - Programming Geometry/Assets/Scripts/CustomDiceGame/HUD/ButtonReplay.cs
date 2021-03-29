using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonReplay : MonoBehaviour
{
    public void Replay()
    {
        // Reset the scoreboard.
        if(ScoreBoard.Instance != null)
        {
            ScoreBoard.Instance.resetScoreBoard();
        }

        // Load the game scene.
        SceneManager.LoadScene("CustomDiceGame");
    }
}
