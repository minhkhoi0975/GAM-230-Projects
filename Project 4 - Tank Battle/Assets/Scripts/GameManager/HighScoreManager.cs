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
    public List<ScoreEntry> highScores = new List<ScoreEntry>();

    // The name of the file that contains high scores.
    const string highScoreFileName = "highscore.txt";

    // Start is called before the first frame update
    void Awake()
    {
        // Load high score from the file.
        LoadHighScore();

        // Update the high score when current scene is "Game Over".
        if(SceneManager.GetActiveScene().name == "GameOver")
        {
            UpdateHighScore();
            SaveHighScore();
        }

        // Show high scores.
        for(int i = 0; i < highScores.Count; i++)
        {
            Debug.Log(highScores[i].name + " " + highScores[i].score);
        }
    }

    // Update the list of high scores.
    public void UpdateHighScore()
    {
        ScoreEntry previousScore = new ScoreEntry(GameManager.Instance.playerName, GameManager.Instance.totalScore);

        for (int i = 0; i < highScores.Count; i++)
        {
            if (previousScore.score > highScores[i].score)
            {
                highScores.Insert(i, previousScore);
                return;
            }
        }

        highScores.Add(previousScore);
    }

    public void LoadHighScore()
    {
        // Clear the list.
        highScores.Clear();

        // Check if the high score file exists.
        if (File.Exists(Application.persistentDataPath + "/" + highScoreFileName))
        {
            Debug.Log(Application.persistentDataPath + "/" + highScoreFileName);

            // Open the file.
            StreamReader highScoreFileStream = new StreamReader(Application.persistentDataPath + "/" + highScoreFileName);

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
        StreamWriter highScoreFileStream = new StreamWriter(Application.persistentDataPath + "/" + highScoreFileName, false);

        // Save the scores.
        for (int i = 0; i < highScores.Count; i++)
        {
            highScoreFileStream.WriteLine(highScores[i].name);
            highScoreFileStream.WriteLine(highScores[i].score);
        }

        highScoreFileStream.Close();
    }
}
