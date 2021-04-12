﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

    public static GameManager Instance { get { return _instance; } }

    public int totalScore = 0;
    public int lives = 3;
    public int ammo = 3;

    public int currentLevelScore = 0;

    private void Awake()
    {
        // If the instance of this class has not been created, create a new one. Otherwise, do not create another one.
        if (_instance == null)
        {
            _instance = this;

            // Do not destroy this object when a new scene is loaded.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetPlayerStats()
    {
        _instance.totalScore = 0;
        _instance.lives = 3;
        _instance.ammo = 3;
    }

    public void UpdateTotalScore()
    {
        _instance.totalScore += _instance.currentLevelScore;
        _instance.currentLevelScore = 0;
    }
}