/**
 * FanScript.cs
 * Description: This script rotates a fan.
 * Programmer: Khoi Ho
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 30.0f;

    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Rotate the fan.
        Vector3 eulerAngleVelocity = new Vector3(0f, 0f, rollSpeed * Time.fixedDeltaTime);
        Quaternion quaternionVelocity = Quaternion.Euler(eulerAngleVelocity);
        rigidBody.MoveRotation(rigidBody.rotation * quaternionVelocity);
    }
}
