/**
 * StartDelay.cs
 * Programmer: Khoi Ho
 * Description: At the beginning of the level, this script pauses the game for a couple of seconds before the game starts.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDelay : MonoBehaviour
{
    public float timeBeforeLevelStarts = 3.0f; // The time before the game starts.

    private void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3.0f;
        while(Time.realtimeSinceStartup < pauseTime)
        {
            yield return null;
        }
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
