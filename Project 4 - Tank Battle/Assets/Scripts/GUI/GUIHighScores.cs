using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIHighScores : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject scoreEntryPrefab;

    // Start is called before the first frame update
    void Start()
    {
        List<ScoreEntry> scores = gameManager.GetComponent<HighScoreManager>().highScores;

        float initialFloatY = 600;
        for(int i = 0; i < scores.Count && i < 5; i++)
        {
            GameObject scoreEntry = Instantiate(scoreEntryPrefab, new Vector3(500, initialFloatY - 69 * i, 0), Quaternion.identity, transform);

            Text textPlayerName = scoreEntry.transform.GetChild(0).GetComponent<Text>();
            textPlayerName.text = scores[i].name;

            Text textScore = scoreEntry.transform.GetChild(1).GetComponent<Text>();
            textScore.text = scores[i].score.ToString();
        }
    }

    public void MainMenu(string mainMenu)
    {
        SceneManager.LoadScene(mainMenu);
    }
}
