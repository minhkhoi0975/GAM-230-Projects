using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;

    Vector3 offset;

    bool isPlayerDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        offset = player.transform.position - gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Always keep the same distance to the player.
            gameObject.transform.position = player.transform.position - offset;
        }

        // If the player is destroyed, replay the level if the player still has lives. Otherwise, go back to the main menu.
        else
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        if (!isPlayerDestroyed)
        {
            GameManager.Instance.lives--;
            GameManager.Instance.currentLevelScore = 0;
            isPlayerDestroyed = true;
        }

        yield return new WaitForSeconds(5);

        if (GameManager.Instance.lives > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }

        // This line is added to avoid the coroutine being called rapidly.
        yield return new WaitForSeconds(100);
    }
}
