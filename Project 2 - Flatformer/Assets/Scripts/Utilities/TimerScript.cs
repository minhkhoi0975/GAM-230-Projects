/**
 * TimerScript.cs
 * Description: This script handles the timer. When the timer reaches 0, the game loads the Game Over menu.
 * Programmer: Khoi Ho
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private float timeLeft = 120.0f;     // When timeLeft reaches 0, the game is over.

    public float TimeLeft 
    { 
        get 
        { 
            return timeLeft; 
        } 
    }

    [SerializeField] string gameOverScene;        // The scene when the game is over.

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0.0f)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(gameOverScene);
        }
    }
}
