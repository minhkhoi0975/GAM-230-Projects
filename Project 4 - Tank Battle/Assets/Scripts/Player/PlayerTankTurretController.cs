using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankTurretController : MonoBehaviour
{
    // Rotation property
    public float angularSpeed = 240.0f;

    // Combat properties
    public GameObject shellTemplate;
    public float fireRateInSeconds = 0.5f;
    public float reloadTimeInSeconds = 1.0f;

    bool readyToFire = true;

    // Update is called once per frame
    void Update()
    {
        // Get the position of the mouse on screen space.
        Vector3 mousePosition = Input.mousePosition;

        // Get the position of the turret on screen space.
        Vector3 turretPosition = Camera.main.WorldToScreenPoint(transform.position);

        // Rotate the turret to the position of the mouse.
        mousePosition.x = mousePosition.x - turretPosition.x;
        mousePosition.y = mousePosition.y - turretPosition.y;
        float angle = Mathf.Atan2(mousePosition.x, mousePosition.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, angle, 0.0f));
        

        /*
        // Rotate the turret.
        float horizontal = Input.GetAxis("RightStickHorizontal");
        float angularVelocity = horizontal * angularSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + angularVelocity, 0f);
        */

        // Shoot.
        if (Input.GetButton("Fire1") && readyToFire)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        if (GameManager.Instance.currentAmmo > 0)
        {
            // Set the initial position of the bullet.
            Vector3 bulletPosition = transform.position + 1.2f * transform.forward + new Vector3(0.0f, 0.5f, 0.0f);

            // Create the shell.
            GameObject shell = Instantiate(shellTemplate, bulletPosition, transform.rotation);
            shell.GetComponent<Shell>().isShotByPlayer = true;

            // Reduce the number of ammo by 1.
            GameManager.Instance.currentAmmo--;

            // Wait before the player can shoot again.
            readyToFire = false;
            yield return new WaitForSeconds(fireRateInSeconds);
            readyToFire = true;
        }

        // Out of ammo? Reload.
        if (GameManager.Instance.currentAmmo <= 0)
        {
            readyToFire = false;
            yield return new WaitForSeconds(reloadTimeInSeconds);
            GameManager.Instance.currentAmmo = GameManager.Instance.ammo;
            readyToFire = true;
        }
    }
}
