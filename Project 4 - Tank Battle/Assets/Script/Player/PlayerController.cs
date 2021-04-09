using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // Movement properties
    public float moveSpeed = 20.0f;
    public float angularSpeed = 90.0f;

    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Get the movement input.
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        // Move the player.
        Vector3 moveVelocity = vertical * transform.forward * moveSpeed * Time.fixedDeltaTime;
        rigidBody.AddForce(moveVelocity, ForceMode.Impulse);

        // Rotate the player.
        float angularVelocity = horizontal * angularSpeed * Time.fixedDeltaTime;
        rigidBody.rotation = Quaternion.Euler(0f, rigidBody.rotation.eulerAngles.y + angularVelocity, 0f);    
    }
}
