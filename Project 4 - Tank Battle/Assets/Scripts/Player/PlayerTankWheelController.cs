/**
 * PlayerTankWheelController.cs
 * Programmer: Khoi Ho (credits to professor Dearbon)
 * Description: This script handles the movement of the whole player tank.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerTankWheelController : MonoBehaviour
{
    // Movement properties
    public float moveSpeed = 20.0f;
    public float dashSpeed = 50.0f;
    public float dashDelay = 3.0f;
    public float angularSpeed = 90.0f;

    Rigidbody rigidBody;
    bool isDashReady = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Get the movement input.
        float vertical = Input.GetAxis("LeftStickVertical");
        float horizontal = Input.GetAxis("LeftStickHorizontal");
        float dash = Input.GetAxisRaw("SpecialAbility");

        // Move the player.
        Vector3 moveVelocity = vertical * transform.forward * moveSpeed * Time.fixedDeltaTime;

        // Dash.
        if(dash != 0.0f && isDashReady)
        {
            // Delay dash.
            StartCoroutine(DelayDash());

            // Dash forward if the player is staying still or moving forward.
            if (Vector3.Dot(moveVelocity.normalized, transform.forward) >= 0.0f)
            {
                moveVelocity = transform.forward * dashSpeed * Time.fixedDeltaTime;
            }

            // Dash backward if the player is moving backward.
            else
            {
                moveVelocity = -transform.forward * dashSpeed * Time.fixedDeltaTime;
            }
        }  

        rigidBody.AddForce(moveVelocity, ForceMode.Impulse);

        // Rotate the player.
        float angularVelocity = horizontal * angularSpeed * Time.fixedDeltaTime;
        rigidBody.rotation = Quaternion.Euler(0f, rigidBody.rotation.eulerAngles.y + angularVelocity, 0f);    
    }

    IEnumerator DelayDash()
    {
        isDashReady = false;
        yield return new WaitForSeconds(dashDelay);
        isDashReady = true;
    }
}
