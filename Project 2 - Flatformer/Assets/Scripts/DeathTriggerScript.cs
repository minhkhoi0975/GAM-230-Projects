using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggerScript : MonoBehaviour
{
    [SerializeField] GameObject player;

    private GameObject playerBody;
    private GameObject playerCamera;

    private Vector3 initialBodyPosition;
    private Quaternion initialBodyRotation;

    private Vector3 initialCameraPosition;
    private Quaternion initialCameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = player.transform.GetChild(0).gameObject;
        playerCamera = player.transform.GetChild(1).gameObject;

        initialBodyPosition = playerBody.transform.position;
        initialBodyRotation = playerBody.transform.rotation;

        initialCameraPosition = playerCamera.transform.position;
        initialCameraRotation = playerCamera.transform.rotation;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerBody.transform.position = initialBodyPosition;
            playerBody.transform.rotation = initialBodyRotation;

            playerCamera.transform.position = initialCameraPosition;
            playerCamera.transform.rotation = initialCameraRotation;
        }
    }
}
