﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // Movement properties
    public float moveSpeed = 20.0f;
    public float angularSpeed = 90.0f;

    Rigidbody rigidBody;

    // Combat properties
    public int ammoCount = 3;
    public GameObject shell;
    public float fireRateInSeconds = 0.5f;
    public float reloadRateInSeconds = 2.0f;

    bool readyToFire = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    /*
    private void Update()
    {
        // Shoot.
        if (Input.GetButton("Fire1") && readyToFire)
        {
            StartCoroutine(Shoot());
        }
    }
    */

    private void FixedUpdate()
    {
        // Get the movement input.
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        // Move the player.
        Vector3 moveVelocity = vertical * transform.forward * moveSpeed * Time.fixedDeltaTime;
        rigidBody.AddForce(moveVelocity, ForceMode.Impulse);

        // Rotate the player.
        float angularVelocity = horizontal * angularSpeed * Time.fixedDeltaTime;
        rigidBody.rotation = Quaternion.Euler(0f, rigidBody.rotation.eulerAngles.y + angularVelocity, 0f);    
    }

    IEnumerator Shoot()
    {
        if (ammoCount > 0)
        {
            // Set the initial position of the bullet.
            Vector3 bulletPosition = transform.position + 1.5f * transform.forward + new Vector3(0.0f, 1.5f, 0.0f);

            // Create the bullet.
            Instantiate(shell, bulletPosition, transform.rotation);

            // Reduce the number of ammo by 1.
            ammoCount--;

            // Wait before the player can shoot again.
            readyToFire = false;
            yield return new WaitForSeconds(fireRateInSeconds);

            // Allow the player to shoot.
            readyToFire = true;
        }
        
        if(ammoCount <= 0)
        {
            readyToFire = false;
            yield return new WaitForSeconds(reloadRateInSeconds);
            ammoCount = 3;
            readyToFire = true;
            Debug.Log("Ammo Reloaded");
        }
    }
}
