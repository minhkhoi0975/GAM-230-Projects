using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public List<int> player1Score = new List<int>();
    public List<int> player2Score = new List<int>();

    private static ScoreBoard instance = null;
    public static ScoreBoard Instance { get { return instance; } }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void addScore(int score)
    {
        if(player1Score.Count == player2Score.Count)
        {
            player1Score.Add(score);
        }
        else
        {
            player2Score.Add(score);
        }
    }

    public int getPlayer1TotalScore()
    {
        int sum = 0;
        foreach(int currentRoundScore in player1Score)
        {
            sum += currentRoundScore;
        }
        return sum;
    }

    public int getPlayer2TotalScore()
    {
        int sum = 0;
        foreach (int scoreCurrentRound in player2Score)
        {
            sum += scoreCurrentRound;
        }
        return sum;
    }

    // Who plays in this turn?
    public int getPlayersTurn()
    {
        return (player1Score.Count == player2Score.Count ? 1 : 2);
    }

    public void resetScoreBoard()
    {
        player1Score.Clear();
        player2Score.Clear();
    }
}
