using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    [SerializeField] private Camera cam;

    public float moveForceMagnitude = 2.0f;
    public float jumpForceMagnitude = 10.0f;

    private int airJumpsLeft = 1;         // How many times can you jump when you are in the air?
    private float isGroundedTimer = -1f;  // Greater than 0?  You're grounded!

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

        Vector3 relativeDirection = new Vector3(horizontal, 0f, vertical).normalized;   // Direction relative to the player.

        if (relativeDirection.magnitude != 0f)
        {
            float targetAngle = Mathf.Atan2(relativeDirection.x, relativeDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveForce = moveForceMagnitude * relativeDirection;

            if(isGroundedTimer < 0.0f)
            {
                moveForce = 0.7f * moveForce;  // Reduce the move force by 30% (0.3) if the player is in the air.
            }

            rigidBody.AddForce(cam.transform.rotation * moveForce, ForceMode.Impulse);
        }

        //rigidBody.velocity = moveVelocity;


        //Vector3 facing = transform.forward;
        //float t = 0.5f;  // Leaving this here (for now)...
        // Linear interpolation
        // Vector3 interpolatedFacing = (1-t)*facing + t*relativeDirection;
        //transform.rotation = Quaternion.LookRotation(interpolatedFacing);
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
    }
}
