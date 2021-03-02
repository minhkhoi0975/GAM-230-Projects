/**
 * DeathTriggerScript.cs
 * Description: This script resets the position of the character when it touches a game object containing this script.
 * Programmer: Khoi Ho
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggerScript : MonoBehaviour
{
    [SerializeField] GameObject player; // The player whose position is reset when they touches this game object.

    private GameObject playerBody;        // Reference to the body of the character.
    private GameObject playerCamera;      // Reference to the camera of the character.

    private Vector3 initialBodyPosition;
    private Quaternion initialBodyRotation;

    private Vector3 initialCameraPosition;
    private Quaternion initialCameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to the body and the camera.
        playerBody = player.transform.GetChild(0).gameObject;
        playerCamera = player.transform.GetChild(1).gameObject;

        // Remember the initial position and rotation of the body.
        initialBodyPosition = playerBody.transform.position;
        initialBodyRotation = playerBody.transform.rotation;

        // Remember the initial position and rotation of the camera.
        initialCameraPosition = playerCamera.transform.position;
        initialCameraRotation = playerCamera.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // Reset the body.
            playerBody.transform.position = initialBodyPosition;
            playerBody.transform.rotation = initialBodyRotation;

            // Reset the camera.
            playerCamera.transform.position = initialCameraPosition;
            playerCamera.transform.rotation = initialCameraRotation;
        }
    }
}
