/**
 * GameManagerScriptScript.cs
 * Author: Khoi Ho
 * Description: This script stores fields that are not reset when the game scene is reloaded.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private static GameManagerScript _instance = null;

    public static GameManagerScript Instance { get { return _instance; } }

    private int highestScore = 0;
    public int HighestScore { get { return highestScore; } set { highestScore = (value < 0 ? 0 : value); } }
    
    private void Awake()
    {
        // If the instance of this class has not been created, create a new one. Otherwise, do not create another one.
        if(_instance == null)
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
}
