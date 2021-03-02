/**
 * CoinScript.cs
 * Description: This script rotates a coin and destroys it when the character touches it.
 * Programmer: Khoi Ho
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private AudioClip pickUpSFX;        // The sound effect when the player picks up a coin.
    [SerializeField] private float rotationSpeed = 30.0f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the coin.
        transform.Rotate(0.0f, 0.0f, rotationSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // Increment the number of collected coins.
            GameManagerScript.Instance.CoinsCollected++;

            // Play a sound effect.
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(pickUpSFX, 0.5f);

            // Destroy the coin.
            Destroy(gameObject);
        }
    }
}
