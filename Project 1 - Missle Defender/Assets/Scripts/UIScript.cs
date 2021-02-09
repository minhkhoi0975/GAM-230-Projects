/**
 * UIScript.cs
 * Author: Khoi Ho
 * Description: This script updates the UI.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public GameObject player;                           // Needed to show the score and the number of lives of the player.
    public GameObject enemySpawner;                     // Needed to show the timer of the enemy spawner.

    private PlayerScript playerScript;
    private EnemySpawnerScript enemySpawnerScript;

    private Text txtTimer;
    private Text txtLives;
    private Text txtScore;
    private Text txtHighestScore;
    private Text txtGameOver;
    private GameObject btnReplay;

    void Start()
    {
        // Get access to the scripts of the player and the enemy spawner.
        playerScript = player.GetComponent<PlayerScript>();
        enemySpawnerScript = enemySpawner.GetComponent<EnemySpawnerScript>();

        // Get access to the elements of the GUI.
        txtTimer = GameObject.Find("Timer").GetComponent<Text>();
        txtLives = GameObject.Find("NumberOfLives").GetComponent<Text>();
        txtScore = GameObject.Find("Score").GetComponent<Text>();
        txtHighestScore = GameObject.Find("HighestScore").GetComponent<Text>();
        txtGameOver = GameObject.Find("GameOver").GetComponent<Text>();
        btnReplay = GameObject.Find("ReplayButton");

        // Hide the "Game Over" message and the "Replay" button.
        txtGameOver.enabled = false;
        btnReplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Update the timer.
        switch(enemySpawnerScript.EnemySpawnerState)
        {
            case EnemySpawnerState.SPAWN:
                txtTimer.color = Color.white;
                break;
            case EnemySpawnerState.NOSPAWN:
                txtTimer.color = Color.yellow;
                break;
            case EnemySpawnerState.TRANSITION:
                txtTimer.color = Color.green;
                break;
        }
        txtTimer.text = string.Format("Wave {0}: {1:0.0}s", enemySpawnerScript.CurrentWave, enemySpawnerScript.Timer);

        // Update the number of lives.
        txtLives.text = "Lives: " + playerScript.NumberOfLives;

        // Update the score.
        txtScore.text = "Score: " + playerScript.Score;

        // Update the highest score.
        txtHighestScore.text = "Highest Score: " + GameManagerScript.Instance.HighestScore;

        // When the number of lives is 0, show the "Game Over!" message and the "Replay" button.
        if(playerScript.NumberOfLives == 0)
        {
            txtGameOver.enabled = true;
            btnReplay.SetActive(true);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("MainScene");
    }
}
