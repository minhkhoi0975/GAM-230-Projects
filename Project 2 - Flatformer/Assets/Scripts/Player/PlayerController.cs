/**
 * PlayerController.cs
 * Description: This script handles the movement of the character.
 * Programmer: Khoi Ho
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private AudioClip jumpSFX; // The sound effect when player jumps.

    public float moveForceMagnitude = 3.0f;
    public float jumpForceMagnitude = 10.0f;

    private int airJumpsLeft = 1;         // How many times can you jump when you are in the air?
    private float isGroundedTimer = -1f;  // Greater than 0? You're grounded!

    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGroundedTimer -= 10f*Time.deltaTime;

        if(Input.GetButtonDown("Jump"))
        {
            // Jump from the ground.
            if (isGroundedTimer > 0f)
            {
                Jump();
                isGroundedTimer = -1;
            }

            // Another jump while in the air.
            else if(airJumpsLeft > 0)
            {
                Jump();
                airJumpsLeft--;
            }
        }
    }

    // FixedUpdate is called once per physics engine "tick"/time step
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 localMoveDirection = new Vector3(horizontal, 0f, vertical).normalized;           // The move direction that is relative to the character itself.

        // Vector3 worldMoveDirection = (cam.transform.rotation * localMoveDirection).normalized;   // The move direction that is relative to the world.
        Vector3 worldMoveDirection = cam.transform.rotation * localMoveDirection;
        worldMoveDirection = new Vector3(worldMoveDirection.x, 0.0f, worldMoveDirection.z).normalized;

        if (worldMoveDirection.magnitude != 0f)
        {
            // Calculate the move force.
            Vector3 moveForce = moveForceMagnitude * worldMoveDirection;

            // Reduce the move force by 65% if the character is in the air.
            if (isGroundedTimer < 0.0f)
            {
                moveForce = 0.35f * moveForce;  
            }

            // Move the character.
            rigidBody.AddForce(moveForce, ForceMode.Impulse);

            // Rotate the character to match the movement.
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(worldMoveDirection), 0.5f);
            // transform.rotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y, 0.0f);
            transform.rotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y, 0.0f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        isGroundedTimer = 1f;
        airJumpsLeft = 1;
    }

    private void Jump()
    {
        Vector3 newVelocity = rigidBody.velocity;
        newVelocity.y = 0f;
        rigidBody.velocity = newVelocity;

        rigidBody.AddForce(jumpForceMagnitude * Vector3.up, ForceMode.Impulse);

        GetComponent<AudioSource>().PlayOneShot(jumpSFX, 0.1f);
    }
}
