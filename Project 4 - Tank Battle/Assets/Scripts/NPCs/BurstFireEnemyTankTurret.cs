﻿/**
 * BurstFireEnemyTankTurret.cs
 * Programmer: Khoi Ho (credits to professor Dearbon)
 * Description: This script handles the turrets of the burst fire enemy tanks.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstFireEnemyTankTurret : MonoBehaviour
{
    // Combat properties
    public int ammoCount = 3;
    public GameObject shell;
    public float fireRateInSeconds = 1.0f;
    public float reloadRateInSeconds = 3.0f;
    public float shellSprayAngle = 30.0f;
    public AudioClip shootingSound;

    int currentAmmoCount;
    bool readyToFire = true;

    GameObject player;  // Reference to the player.

    private void Start()
    {
        currentAmmoCount = ammoCount;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(player != null)
        {
            // Rotate the turret toward the player.
            Vector3 lookDirectionVector = player.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirectionVector.normalized), 0.1f);

            // Shoot
            if (readyToFire)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        if (currentAmmoCount > 0)
        {
            // Set the initial position of the 3 shells.
            Vector3 bulletPosition = transform.position + 1.2f * transform.forward + new Vector3(0.0f, 0.5f, 0.0f);
            Quaternion shell1Rotation = transform.rotation;
            Quaternion shell2Rotation = Quaternion.Euler(shell1Rotation.eulerAngles + new Vector3(0.0f, -shellSprayAngle / 2.0f, 0.0f));
            Quaternion shell3Rotation = Quaternion.Euler(shell1Rotation.eulerAngles + new Vector3(0.0f,  shellSprayAngle / 2.0f, 0.0f));

            // Create the 3 shells
            Instantiate(shell, bulletPosition, shell1Rotation);
            Instantiate(shell, bulletPosition, shell2Rotation);
            Instantiate(shell, bulletPosition, shell3Rotation);

            // Create sound effect.
            AudioSource.PlayClipAtPoint(shootingSound, bulletPosition);

            // Reduce the number of ammo by 1.
            currentAmmoCount--;

            // Wait before the player can shoot again.
            readyToFire = false;
            yield return new WaitForSeconds(fireRateInSeconds);

            // Allow the enemy tank to shoot.
            readyToFire = true;
        }

        // Out of ammo? Reload.
        if (currentAmmoCount <= 0)
        {
            // Wait before the player can shoot again.
            readyToFire = false;
            yield return new WaitForSeconds(reloadRateInSeconds);

            // Reload.
            currentAmmoCount = ammoCount;

            // Allow the enemy tank to shoot.
            readyToFire = true;
        }
    }
}
