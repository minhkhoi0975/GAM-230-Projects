using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryTankTurret : MonoBehaviour
{
    // Combat properties
    public int ammoCount = 3;
    public GameObject shell;
    public float fireRateInSeconds = 0.5f;
    public float reloadRateInSeconds = 2.0f;

    bool readyToFire = true;

    private void Update()
    {
        if (readyToFire)
        {
            StartCoroutine(Shoot());
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

            // Allow the player to shoot.
            readyToFire = true;
        }

        if (ammoCount <= 0)
        {
            readyToFire = false;
            yield return new WaitForSeconds(reloadRateInSeconds);
            ammoCount = 3;
            readyToFire = true;
            Debug.Log("Ammo Reloaded");
        }
    }
}
