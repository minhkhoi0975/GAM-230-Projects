﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDelay : MonoBehaviour
{
    public float timeBeforeLevelStarts = 3.0f;

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