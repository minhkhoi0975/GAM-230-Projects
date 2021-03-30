/**
 * ButtonPass.cs
 * Programmer: Khoi Ho
 * Description: The method Pass() is called when the player clicks the "Pass" button. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPass : MonoBehaviour
{
    ScoreCalculator scoreCalculator;    // Reference to the score calculator.

    // Start is called before the first frame update
    void Start()
    {
        scoreCalculator = GameObject.Find("ScoreCalculator").GetComponent<ScoreCalculator>();
    }

    public void Pass()
    {
        // Add score to the score board.
        ScoreBoard.Instance.addScore(scoreCalculator.Score);

        // Load the "Game Over" scene if player 2 reaches 500 points first, or player 1 reaches 500 points first and player 2 cannot get greater score than that of player 1.
        int player1TotalScore = ScoreBoard.Instance.getPlayer1TotalScore();
        int player2TotalScore = ScoreBoard.Instance.getPlayer2TotalScore();
        
        if((ScoreBoard.Instance.player2Score.Count == ScoreBoard.Instance.player1Score.Count) && 
            ((player2TotalScore >= 500 && player1TotalScore < player2TotalScore) || (player1TotalScore >= 500 && player2TotalScore < player1TotalScore)))
        {
            SceneManager.LoadScene("GameOver");
            return;
        }

        // Reload the scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
