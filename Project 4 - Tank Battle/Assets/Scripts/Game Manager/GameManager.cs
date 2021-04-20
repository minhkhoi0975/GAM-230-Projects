using System.Collections;
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

    [HideInInspector] public int currentLives;
    [HideInInspector] public int currentAmmo;

    private void Awake()
    {
        // If the instance of this class has not been created, create a new one. Otherwise, do not create another one.
        if (_instance == null)
        {
            this.currentLives = lives;
            this.currentAmmo = ammo;
            _instance = this;

            // Do not destroy this object when a new scene is loaded.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            _instance.currentLives = _instance.lives;
            _instance.currentAmmo = _instance.ammo;
            _instance.currentLevelScore = 0;
            Destroy(gameObject);
        }
    }

    public void ResetPlayerStats()
    {
        _instance.totalScore = 0;
        _instance.currentLives = _instance.lives;
        _instance.currentAmmo = _instance.ammo;
        _instance.currentLevelScore = 0;
    }

    public void UpdateTotalScore()
    {
        _instance.totalScore += _instance.currentLevelScore;
        _instance.currentLevelScore = 0;
    }
}
