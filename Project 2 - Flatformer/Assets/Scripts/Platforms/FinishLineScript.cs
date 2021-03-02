/**
 * FinishLineScript.cs
 * Description: This script loads a scene when the player reaches the finish line.
 * Programmer: Khoi Ho
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineScript : MonoBehaviour
{
    [SerializeField] private string nextScene;

    private void OnTriggerEnter(Collider other)
    {
        // Load the next scene when the player reaches the finish line.
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
