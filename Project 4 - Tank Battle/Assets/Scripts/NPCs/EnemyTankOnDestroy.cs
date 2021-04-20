/**
 * EnemyTankOnDestroy.cs
 * Programmer: Khoi Ho (credits to professor Dearbon)
 * Description: This script stores what debris model and explosion effect will be created when the enemy tank is destroyed.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankOnDestroy : MonoBehaviour
{
    static public int tankCount = 0;

    public int health = 1;  // How many hits before the tank is destroyed.
    public int score = 500; // The score the player gains after destroying the tank.

    public GameObject debrisPrefab;
    public GameObject explosionPrefab;
    public AudioClip hitSound;

    private void Awake()
    {
        tankCount++;
    }

    private void OnDestroy()
    {
        tankCount--;
    }
}
