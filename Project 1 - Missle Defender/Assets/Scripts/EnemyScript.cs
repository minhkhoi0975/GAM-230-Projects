using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;            // The player the enemy must attack.
    public float moveSpeed = 5.0f;       // The move speed of the enemy.
    public float rotationSpeed = 30.0f;  // The rotation speed of the enemy.

    private PlayerScript playerScript;

    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Translate towards the target.
            transform.position += (player.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;

            // Rotate the enemy around the axis that goes throw the enemy and the target.
            transform.RotateAround(transform.position, player.transform.position - transform.position, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            // Increase player's score.
            playerScript.Score = playerScript.Score + 1;

            // If the score is greater than the highest score, update the highest score.
            if(playerScript.Score > GameManagerScript.Instance.HighestScore)
            {
                GameManagerScript.Instance.HighestScore = playerScript.Score;
            }

            // Destroy the enemy and the bullet.
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
