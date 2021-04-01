using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public string nextScene;
    public float timeBeforeNextScene = 5.0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(WaitBeforeNextScene());
        }
    }

    IEnumerator WaitBeforeNextScene()
    {
        // Wait.
        yield return new WaitForSeconds(timeBeforeNextScene);

        // Load the next scene.
        SceneManager.LoadScene(nextScene);
    }
}
