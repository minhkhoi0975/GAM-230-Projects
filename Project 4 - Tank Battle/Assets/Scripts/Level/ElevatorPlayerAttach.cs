using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlayerAttach : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // other.GetComponent<Rigidbody>().useGravity = false;
            other.transform.parent = transform;
            Debug.Log("Player enters the moving platform.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // other.GetComponent<Rigidbody>().useGravity = true;
            other.transform.parent = null;
            Debug.Log("Player leaves the moving platform.");
        }
    }
}
