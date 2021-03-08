/**
 * CameraController.cs
 * Description: This script handles the movement of a camera.
 * Programmer: Khoi Ho
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 targetOffset = new Vector3(0, 3, -8);
    [SerializeField] private float sensitivityX = 100.0f;
    [SerializeField] private float sensitivityY = 100.0f;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, transform.up, Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime);
        transform.RotateAround(target.transform.position, transform.right, -Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime);
        
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0.0f); // Fix the z-axis rotation.

        // Move the camera to keep the đistance between itself and the target.
        transform.position = target.transform.position + transform.rotation * targetOffset;
    }
}
