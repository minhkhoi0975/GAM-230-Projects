/**
 * CustomDiceGameHUDUpdate.cs
 * Programmer: Khoi Ho
 * Description: Update the HUD of the game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomDiceGameHUDUpdate : MonoBehaviour
{
    // Refernce to the buttons.
    Button btnRollTheDice;
    Button btnPass;

    // Reference to the textboxes.
    Text txtPlayersTurn;
    Text txtScore;
    Text txtPlayer1Score;
    Text txtPlayer2Score;
    
    // Start is called before the first frame update
    void Start()
    {
        btnRollTheDice = GameObject.Find("Canvas/ButtonRollTheDice").GetComponent<Button>();
        btnPass = GameObject.Find("Canvas/ButtonPass").GetComponent<Button>();

        txtScore = GameObject.Find("/Canvas/TextScore").GetComponent<Text>();

        // Show whose turn it is.
        txtPlayersTurn = GameObject.Find("/Canvas/TextPlayersTurn").GetComponent<Text>();
        txtPlayersTurn.text = "Player " + ScoreBoard.Instance.getPlayersTurn();

        // Show Player 1's total score.
        txtPlayer1Score = GameObject.Find("/Canvas/TextPlayer1Score").GetComponent<Text>();
        txtPlayer1Score.text = "Player 1 Score: " + ScoreBoard.Instance.getPlayer1TotalScore() + "/500";
        
        // Show Player 2's total score.
        txtPlayer2Score = GameObject.Find("/Canvas/TextPlayer2Score").GetComponent<Text>();
        txtPlayer2Score.text = "Player 2 Score: " + ScoreBoard.Instance.getPlayer2TotalScore() + "/500";
    }

    // Update is called once per frame
    void Update()
    {
        // Update the score.
        ScoreCalculator scoreCalculator = GameObject.Find("ScoreCalculator").GetComponent<ScoreCalculator>();
        txtScore.text = "Score: " + scoreCalculator.Score + " (" + scoreCalculator.showDiceInfo() + ")";
    }
}
