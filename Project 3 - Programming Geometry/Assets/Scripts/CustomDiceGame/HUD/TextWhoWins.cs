using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWhoWins : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Show which player wins the game.
        Text txtPlayerWins = gameObject.GetComponent<Text>();
        if(ScoreBoard.Instance != null && ScoreBoard.Instance.getPlayer1TotalScore() > ScoreBoard.Instance.getPlayer2TotalScore())
        {
            txtPlayerWins.text = "Player 1 Wins!";
        }
        else
        {
            txtPlayerWins.text = "Player 2 Wins!";
        }
    }
}
