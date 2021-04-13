using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankTurret : MonoBehaviour
{
    // Combat properties
    public int ammoCount = 3;
    public GameObject shell;
    public float fireRateInSeconds = 1.0f;
    public float reloadRateInSeconds = 3.0f;
    // public float visionRadius = 20.0f;

    bool readyToFire = true;

    GameObject player;  // Reference to the player.

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if 
            (
            player != null 
            // && Vector3.Distance(player.transform.position, transform.position) <= 20.0f
            )
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
        if (ammoCount > 0)
        {
            // Set the initial position of the bullet.
            Vector3 bulletPosition = transform.position + 1.2f * transform.forward + new Vector3(0.0f, 0.5f, 0.0f);

            // Create the bullet.
            Instantiate(shell, bulletPosition, transform.rotation);

            // Reduce the number of ammo by 1.
            ammoCount--;

            // Wait before the player can shoot again.
            readyToFire = false;
            yield return new WaitForSeconds(fireRateInSeconds);

            // Allow the enemy tank to shoot.
            readyToFire = true;
        }

        // Out of ammo? Reload.
        if (ammoCount <= 0)
        {
            // Wait before the player can shoot again.
            readyToFire = false;
            yield return new WaitForSeconds(reloadRateInSeconds);

            // Reload.
            ammoCount = 3;

            // Allow the enemy tank to shoot.
            readyToFire = true;
        }
    }
}
