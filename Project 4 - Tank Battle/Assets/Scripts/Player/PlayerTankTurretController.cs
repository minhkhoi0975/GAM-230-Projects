/**
 * PlayerTankTurretController.cs
 * Programmer: Khoi Ho (credits to professor Dearbon)
 * Description: This script handles the control of the player tank's turret.
 *              There are 3 ways to rotate the turret: left/right arrows, mouse movement, and right trigger on Xbox One controller.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankTurretController : MonoBehaviour
{
    // Rotation property
    public float angularSpeed = 240.0f;

    // Combat properties   
    public float fireRateInSeconds = 0.5f;
    public float reloadTimeInSeconds = 1.0f;
    public GameObject shellTemplate;
    public AudioClip shootingSound;

    bool isControlledWithMouse = false; // true = Mouse, false = Arrow Keys/Right Trigger
    bool readyToFire = true;

    // Update is called once per frame
    void Update()
    {
        // Get the for the turret.
        float mouseInputX = Input.GetAxisRaw("Mouse X");
        float mouseInputY = Input.GetAxisRaw("Mouse Y");
        float arrowKeyInput = Input.GetAxis("RightStickHorizontal");

        // Check the kind of input.
        if(mouseInputX != 0 || mouseInputY != 0)
        {
            isControlledWithMouse = true;
        }
        else if(arrowKeyInput != 0)
        {
            isControlledWithMouse = false;
        }     
        
        // Rotate the turret using mouse.
        if (isControlledWithMouse && Time.timeScale != 0.0f)
        {
            // Get the position of the mouse on screen space.
            Vector3 mousePosition = Input.mousePosition;

            // Get the position of the turret on screen space.
            Vector3 turretPosition = Camera.main.WorldToScreenPoint(transform.position);

            // Find the new angle.
            mousePosition.x = mousePosition.x - turretPosition.x;
            mousePosition.y = mousePosition.y - turretPosition.y;
            float newAngle = Mathf.Atan2(mousePosition.x, mousePosition.y) * Mathf.Rad2Deg;

            // Rotate the turret.
            //Quaternion newRotation = Quaternion.Euler(0f, newAngle, 0f);
            //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, newAngle, 0f);
        }
        // Rotate the turret using arrow keys/right stick.
        else
        {
            // Fix the Xbox One controller issue.
            if(arrowKeyInput < 0)
            {
                arrowKeyInput = -1;
            }
            else if(arrowKeyInput > 0)
            {
                arrowKeyInput = 1;
            }
            else
            {
                arrowKeyInput = 0;
            }
            
            // Find the new angle.
            float newAngle = transform.rotation.eulerAngles.y - arrowKeyInput * angularSpeed;

            // Rotate the turret.
            Quaternion newRotation = Quaternion.Euler(0f, newAngle, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime);
        }

        // Fire a shell using LMB/Space/Right trigger.
        if (Input.GetAxis("Fire1") != 0 && readyToFire)
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

            // Create sound effect.
            AudioSource.PlayClipAtPoint(shootingSound, bulletPosition);

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
            GameManager.Instance.currentAmmo = GameManager.Instance.maxAmmo;
            readyToFire = true;
        }
    }
}
