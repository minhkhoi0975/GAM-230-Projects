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
        if(player!=null)
        {
            // Rotate the turret toward the player.
            Vector3 lookDirectionVector = (player.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirectionVector), 0.1f);

            // Shoot
            if (canSeePlayer() && readyToFire)
            {
                StartCoroutine(Shoot());
            }
        }  
    }

    IEnumerator Shoot()
    {
        if (currentAmmoCount > 0)
        {
            // Set the initial position of the bullet.
            Vector3 bulletPosition = transform.position + 1.2f * transform.forward + new Vector3(0.0f, 0.5f, 0.0f);

            // Create the bullet.
            Instantiate(shell, bulletPosition, transform.rotation);

            // Reduce the number of ammo by 1.
            currentAmmoCount--;

            // Wait before the enemy can shoot again.
            readyToFire = false;
            yield return new WaitForSeconds(fireRateInSeconds);

            // Allow the enemy tank to shoot.
            readyToFire = true;
        }

        // Out of ammo? Reload.
        if (currentAmmoCount <= 0)
        {
            // Wait before the enemy can shoot again.
            readyToFire = false;
            yield return new WaitForSeconds(reloadRateInSeconds);

            // Reload.
            currentAmmoCount = ammoCount;

            // Allow the enemy tank to shoot.
            readyToFire = true;
        }
    }

    bool canSeePlayer()
    {
        RaycastHit raycastHit;
        if
        (
            Physics.Raycast(transform.position, (player.transform.position - transform.position).normalized, out raycastHit, Mathf.Infinity)
            && raycastHit.collider.tag == "Player"
        )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
