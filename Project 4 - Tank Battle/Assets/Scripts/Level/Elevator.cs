/**
 * HUDUpdatePlayerStats.cs
 * Programmer: Khoi Ho (credits to professor Dearbon)
 * Description: This script updates the player stats on HUD.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints = new List<Transform>(); // List of waypoints.
    public float travelingTime = 2f;                                            // The time it takes to travel from the first waypoint to the last waypoint.
    public float waitTime = 3.0f;                                               // The time before the elevator starts moving in reserve direction.
    private float nextWaypointTimer;                                            // The remaining time to get to the next waypoint.

    private Vector3 lastPosition;
    private int nextIndex = 0;
    private bool canMove = true;

    Rigidbody platformRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        nextWaypointTimer = travelingTime;
        lastPosition = transform.position;
        platformRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (canMove)
        {
            StartCoroutine(MoveElevator());
        }
    }

    IEnumerator MoveElevator()
    {
        nextWaypointTimer -= Time.deltaTime;
        if (nextWaypointTimer < 0f)
        {
            nextWaypointTimer = travelingTime;
            lastPosition = waypoints[nextIndex].position;

            // Now start moving to the next waypoint.
            ++nextIndex;
            if (nextIndex >= waypoints.Count)
                nextIndex = 0;

            canMove = false;
            yield return new WaitForSeconds(waitTime);
            canMove = true;
        }

        float t = (travelingTime - nextWaypointTimer) / travelingTime;                        // Modify timer to fit into 0-1 range.
        transform.position = Vector3.Lerp(lastPosition, waypoints[nextIndex].position, t); 
    }
}
