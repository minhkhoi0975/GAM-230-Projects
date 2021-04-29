/**
 * GameManager.cs
 * Programmer: Khoi Ho
 * Description: This script stores player stats.
 */

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

    public static GameManager Instance { get { return _instance; } }

    // Player's name.
    public string playerName = "Empty";

    // Player's stats.
    public int totalScore = 0;
    [HideInInspector] public int currentLevelScore = 0;
    public int maxLives = 10;
    [HideInInspector] public int currentLives;
    public int maxAmmo = 5;   
    [HideInInspector] public int currentAmmo;

    private void Awake()
    {
        // If the instance of this class has not been created, create a new one. Otherwise, do not create another one.
        if (_instance == null)
        {           
            // Set player stats.
            this.currentLives = maxLives;
            this.currentAmmo = maxAmmo;

            _instance = this;

            // Do not destroy this object when a new scene is loaded.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Reset the ammo.
            _instance.currentAmmo = _instance.maxAmmo;

            // Add the score of the previous level to the total score.
            UpdateTotalScore();

            Destroy(gameObject);
        }
    }

    public void ResetPlayerStats()
    {
        _instance.totalScore = 0;
        _instance.currentLives = _instance.maxLives;
        _instance.currentAmmo = _instance.maxAmmo;
        _instance.currentLevelScore = 0;
    }

    // Add the score of the current level to the total score.
    public void UpdateTotalScore()
    {
        _instance.totalScore += _instance.currentLevelScore;
        _instance.currentLevelScore = 0;
    }
}
