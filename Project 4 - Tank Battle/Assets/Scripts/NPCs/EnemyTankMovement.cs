/**
 * EnemyTankMovement.cs
 * Programmer: Khoi Ho (credits to professor Dearbon)
 * Description: This script handles the movement of the enemy tanks.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyTankMovement : MonoBehaviour
{
    GameObject player;          // Reference to the player.
    NavMeshAgent navMeshAgent;  // Reference to navmesh agent.

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player!=null)
        {
            navMeshAgent.SetDestination(player.transform.position);
        }
    }
}
