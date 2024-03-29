﻿/**
 * Elevator.cs
 * Programmer: Khoi Ho (credits to professor Dearbon)
 * Description: This script attaches the player to an elevator when the player stands on it.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlayerAttach : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // If the player enters the elevator, attach the player to the elevator.
        if (other.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the player leaves the elevator, detach the player from the elevator.
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
