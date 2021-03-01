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
    private float isGroundedTimer = -1f;  // Greater than 0?  You're grounded!

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
            if (isGroundedTimer > 0f)
            {
                Jump();
                isGroundedTimer = -1;
            }
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

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;   // Direction relative to the player.

        if (moveDirection.magnitude != 0f)
        {
            // rigidBody.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveForce = moveForceMagnitude * moveDirection;

            if(isGroundedTimer < 0.0f)
            {
                moveForce = 0.35f * moveForce;  // Reduce the move force by 65% if the player is in the air.
            }

            rigidBody.AddForce(cam.transform.rotation * moveForce, ForceMode.Impulse);

            // Rotate the character to match the movement.
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(cam.transform.rotation*moveDirection), 0.5f);
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
