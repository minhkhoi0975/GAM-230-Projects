using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints = new List<Transform>();
    public float travelingTime = 2f;  // The time it takes to travel from the first point to the last point.
    public float waitTime = 3.0f;     // The time before the elevator moves in reserve direction.
    private float nextWaypointTimer;

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
        /*
        nextWaypointTimer -= Time.deltaTime;
        if (nextWaypointTimer < 0f)
        {
            nextWaypointTimer = maxWaypointTimer;
            lastPosition = waypoints[nextIndex].position;

            // Now start moving to the next waypoint
            ++nextIndex;
            if (nextIndex >= waypoints.Count)
                nextIndex = 0;
        }

        float t = (maxWaypointTimer - nextWaypointTimer) / maxWaypointTimer;  // Modify timer to fit into 0-1 range
        transform.position = Vector3.Lerp(lastPosition, waypoints[nextIndex].position, t);
        */

        if (canMove)
        {
            StartCoroutine(MoveElevator());
        }
    }

    /*
    // Update is called once per frame
    void FixedUpdate()
    {
        nextWaypointTimer -= Time.fixedDeltaTime;
        if (nextWaypointTimer < 0f)
        {
            nextWaypointTimer = maxWaypointTimer;
            lastPosition = waypoints[nextIndex].position;

            // Now start moving to the next waypoint
            ++nextIndex;
            if (nextIndex >= waypoints.Count)
                nextIndex = 0;
        }

        float t = (maxWaypointTimer - nextWaypointTimer) / maxWaypointTimer;  // Modify timer to fit into 0-1 range
        platformRigidBody.position = Vector3.Lerp(lastPosition, waypoints[nextIndex].position, t);
    }
    */

    IEnumerator MoveElevator()
    {
        nextWaypointTimer -= Time.deltaTime;
        if (nextWaypointTimer < 0f)
        {
            nextWaypointTimer = travelingTime;
            lastPosition = waypoints[nextIndex].position;

            // Now start moving to the next waypoint
            ++nextIndex;
            if (nextIndex >= waypoints.Count)
                nextIndex = 0;

            canMove = false;
            yield return new WaitForSeconds(waitTime);
            canMove = true;
        }

        float t = (travelingTime - nextWaypointTimer) / travelingTime;// Modify timer to fit into 0-1 range
        transform.position = Vector3.Lerp(lastPosition, waypoints[nextIndex].position, t); 
    }
}
