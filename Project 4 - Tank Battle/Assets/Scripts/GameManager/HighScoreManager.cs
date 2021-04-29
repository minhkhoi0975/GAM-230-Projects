/**
 * HighScoreManager.cs
 * Programmer: Khoi Ho
 * Description: This script loads, updates, and saves the list of high scores.
 */

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreEntry
{
    public string name;
    public int score;

    public ScoreEntry(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}

public class HighScoreManager : MonoBehaviour
{
    // The name of the file that contains high scores.
    const string HIGH_SCORE_FILE_NAME = "highscore.txt";

    // List of high scores.
    public List<ScoreEntry> highScores = new List<ScoreEntry>();

    // Start is called before the first frame update
    void Awake()
    {
        // Load high score from the file.
        LoadHighScore();

        // Update the high score if current scene is "Game Over".
        if(SceneManager.GetActiveScene().name == "GameOver")
        {
            UpdateHighScore();
            SaveHighScore();
        }
    }

    // Update the list of high scores.
    public void UpdateHighScore()
    {
        // Get the score from the previous game.
        ScoreEntry previousScore = new ScoreEntry(GameManager.Instance.playerName, GameManager.Instance.totalScore);

        // Check if this score is higher than any scores on top.
        for (int i = 0; i < highScores.Count; i++)
        {
            if (previousScore.score > highScores[i].score)
            {
                highScores.Insert(i, previousScore);
                return;
            }
        }

        // If this score is the lowest, add it to the end of the list.
        highScores.Add(previousScore);
    }

    public void LoadHighScore()
    {
        // Clear the list.
        highScores.Clear();

        // Check if the high score file exists.
        if (File.Exists(Application.persistentDataPath + "/" + HIGH_SCORE_FILE_NAME))
        {
            // Open the file.
            StreamReader highScoreFileStream = new StreamReader(Application.persistentDataPath + "/" + HIGH_SCORE_FILE_NAME);

            // Load the high scores from the file.
            while(!highScoreFileStream.EndOfStream)
            {
                string playerName = highScoreFileStream.ReadLine();
                int score = int.Parse(highScoreFileStream.ReadLine());
                highScores.Add(new ScoreEntry(playerName, score));
            }

            // Close the file.
            highScoreFileStream.Close();
        }
    }

    public void SaveHighScore()
    {
        // Open the high score file.
        StreamWriter highScoreFileStream = new StreamWriter(Application.persistentDataPath + "/" + HIGH_SCORE_FILE_NAME, false);

        // Save the scores.
        for (int i = 0; i < highScores.Count; i++)
        {
            highScoreFileStream.WriteLine(highScores[i].name);
            highScoreFileStream.WriteLine(highScores[i].score);
        }

        // Close the file.
        highScoreFileStream.Close();
    }
}
