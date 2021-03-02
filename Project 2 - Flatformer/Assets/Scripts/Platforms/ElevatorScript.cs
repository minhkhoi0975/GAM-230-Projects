/**
 * ElevatorScript.cs
 * Description: This script makes a game object move back and forth between 2 points.
 * Programmer: Khoi Ho
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public Transform position1;
    public Transform position2;

    private Rigidbody rigidBody;
    private float t = 0.0f;          // t = 0: The game object is at position 1. t = 1: The game object is at position 2.
    private float direction = 1.0f;  // direction = 1: The game object moves from position 1 to position 2. direction = -1: The game objects moves from position 2 to position 1.

    private void Start()
    {
        // If the game object is not at postion 1, move it to position 1.
        transform.position = position1.position;

        // Reference to the rigid body of the game object.
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Move the game object.
        rigidBody.MovePosition(Vector3.Lerp(position1.position, position2.position, t));

        // Calculate where the game object is between position 1 and position 2.
        t += direction * Time.deltaTime / 1;

        // Reverse the direction if the game object moves to the end of the path.
        if(t <= 0.0f || t >= 1.0f)
        {
            direction = -direction;
        }
    }
}
