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

    // Update is called once per frame
    void Update()
    {      
        // Rotate the camera to look at the target.
        Vector3 targetXZ = target.transform.position;
        targetXZ.y = 0f;

        Vector3 sourceXZ = transform.position;
        sourceXZ.y = 0f;

        Vector3 toTarget = (targetXZ - sourceXZ).normalized;
        transform.rotation = Quaternion.LookRotation(toTarget);
          
        // Move the camera to keep the đistance between itself and the target.
        transform.position = target.transform.position + transform.rotation * targetOffset;
    }
}
