using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPass : MonoBehaviour
{
    GameObject scoreCalculator;    // Reference to the score calculator.

    GameObject buttonRollTheDice;  // Reference to the "Roll the Dice" button.

    // Start is called before the first frame update
    void Start()
    {
        scoreCalculator = GameObject.Find("ScoreCalculator");

        buttonRollTheDice = GameObject.Find("ButtonRollTheDice");
    }

    public void Pass()
    {
        // Add score to the player's score board.
        ScoreBoard.Instance.addScore(scoreCalculator.GetComponent<ScoreCalculator>().Score);

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
