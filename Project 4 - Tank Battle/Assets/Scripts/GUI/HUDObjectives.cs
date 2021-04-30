/**
 * HUDObjectives.cs
 * Programmer: Khoi Ho
 * Description: This script displays the number of collectibles and enemies in the level.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDObjectives : MonoBehaviour
{
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = 
            "Collectibles: " + Collectible.collectibleCount + "\n"
            + "Enemies: " + EnemyTankOnDestroy.tankCount;
    }
}
