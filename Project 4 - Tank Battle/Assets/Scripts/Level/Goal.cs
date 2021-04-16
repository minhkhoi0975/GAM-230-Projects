using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
public class Goal : MonoBehaviour
{
    public string nextScene;
    public float timeBeforeNextScene = 5.0f;

    /*
    public List<GameObject> requiredCollectibles;  // These items that must be collected before the goal can be enabled.
    */

    private void Start()
    {
        // Disable the goal.
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    void Update()
    {
        /*
        // Remove collected items.
        int i = 0;
        while(i < requiredCollectibles.Count)
        {
            if(requiredCollectibles[i] == null)
            {
                requiredCollectibles.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }

        // Enable the goal when all the items are collected.
        if (requiredCollectibles.Count == 0)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        */

        // Enable the goal if all the collectibles are collected and all the enemies are destroyed.
        if(Collectible.collectibleCount == 0 && EnemyTankOnDestroy.tankCount == 0)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
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

        // Update the total score.
        GameManager.Instance.UpdateTotalScore();

        // Load the next scene.
        SceneManager.LoadScene(nextScene);
    }
}
