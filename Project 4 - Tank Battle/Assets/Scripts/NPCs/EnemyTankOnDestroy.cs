using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankOnDestroy : MonoBehaviour
{
    static public int tankCount = 0;

    public int health = 1;
    public int score = 500;

    public GameObject debrisPrefab;
    public GameObject explosionPrefab;

    private void Awake()
    {
        tankCount++;
    }

    private void OnDestroy()
    {
        tankCount--;
    }
}
