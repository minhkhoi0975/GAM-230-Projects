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
    void Update()
    {
        // transform.Rotate(0.0f, 0.0f, rollSpeed * Time.deltaTime);

        Vector3 eulerAngleVelocity = new Vector3(0f, 0f, rollSpeed * Time.deltaTime);
        Quaternion quaternionVelocity = Quaternion.Euler(eulerAngleVelocity);
        rigidBody.MoveRotation(rigidBody.rotation * quaternionVelocity);
    }
}
