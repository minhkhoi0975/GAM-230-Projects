using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankTurretController : MonoBehaviour
{
    // Combat properties
    public int ammoCount = 3;
    public GameObject shell;
    public float fireRateInSeconds = 0.5f;
    public float reloadRateInSeconds = 2.0f;

    bool readyToFire = true;

    // Update is called once per frame
    void Update()
    {
        // Get the position of the mouse.
        Vector3 mousePosition = Input.mousePosition;
        Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);

        // Rotate the turret to the position of the mouse.
        mousePosition.x = mousePosition.x - objectPosition.x;
        mousePosition.y = mousePosition.y - objectPosition.y;
        float angle = Mathf.Atan2(mousePosition.x, mousePosition.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, angle, 0.0f));

        // Shoot.
        if (Input.GetButton("Fire1") && readyToFire)
        {
            /*
            // Set the initial position of the bullet.
            Vector3 bulletPosition = transform.position + 1.6f * transform.forward + new Vector3(0.0f, 1.5f, 0.0f);
            Instantiate(shell, bulletPosition, transform.rotation, gameObject.transform);
            */

            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        if (ammoCount > 0)
        {
            // Set the initial position of the bullet.
            Vector3 bulletPosition = transform.position + 1.2f * transform.forward;

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
