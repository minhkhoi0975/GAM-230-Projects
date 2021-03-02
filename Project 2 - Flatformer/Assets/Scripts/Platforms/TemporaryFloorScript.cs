/**
 * TemporaryFloorScript.cs
 * Description: This script makes a floor appear/disappear after a specified amount of time.
 * Programmer: Khoi Ho
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryFloorScript : MonoBehaviour
{
    [SerializeField] private bool isInitiallyEnabled = true;   // Is the floor initially visible?
    [SerializeField] private float time = 2.0f;                // How long before the floor disappears/reappears.

    private float timeLeft;
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = time;
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();

        // If the floor is set to be initially invisiable, make it invisible.
        if(isInitiallyEnabled)
        {
            meshRenderer.enabled = false;
            meshCollider.enabled = false;          
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Reduce cooldown.
        timeLeft -= Time.deltaTime;

        // When the cooldown reaches 0, make the floor appear/disappear.
        if(timeLeft < 0.0f)
        {
            meshRenderer.enabled = !meshRenderer.enabled;
            meshCollider.enabled = !meshCollider.enabled;
            timeLeft = time;
        }
    }
}
