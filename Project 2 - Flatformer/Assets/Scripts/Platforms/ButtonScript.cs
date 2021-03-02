/**
 * ButtonScript.cs
 * Description: This script makes game objects appear/disappear when the player presses a button.
 * Programmer: Khoi Ho
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private AudioClip buttonPresseSFX;           // The sound effect when the player clicks the button.

    [SerializeField] private GameObject[] affectedGameObjects;    // The game objects that appear/disappear when the button is pressed.

    [SerializeField] private float cooldown = 5.0f;               // How long before the switch can be pressed again.
    private float currentCoolDown = 0.0f;

    private void Update()
    {
        // Reduce the cooldown. Don't make it go below 0.
        if(currentCoolDown > 0f)
        {
            currentCoolDown -= Time.deltaTime;
        }
        else
        {
            currentCoolDown = 0.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Make the game objects appear/disappear when the player touches the button and the cooldown reaches 0.
        if(other.CompareTag("Player") && currentCoolDown == 0.0f)
        {
            foreach(GameObject gameObject in affectedGameObjects)
            {
                MeshRenderer meshRender = gameObject.GetComponent<MeshRenderer>();
                if (meshRender != null)
                {
                    meshRender.enabled = !meshRender.enabled;
                }

                MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
                if (meshCollider != null)
                {
                    meshCollider.enabled = !meshCollider.enabled;
                }
            }

            // Reset the cooldown.
            currentCoolDown = cooldown;

            // Play a sound effect.
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(buttonPresseSFX, 1.0f);
        }
    }
}
