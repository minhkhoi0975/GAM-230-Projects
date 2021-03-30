/**
 * RollIndividualDice.cs
 * Programmer: Khoi Ho
 * Description: When the player clicks a die, this script rolls it.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollIndividualDie : MonoBehaviour
{
    // Reference to the player's turn
    PlayersTurn playersTurn;

    // Start is called before the first frame update
    void Start()
    {
        playersTurn = GameObject.Find("PlayersTurn").GetComponent<PlayersTurn>();
    }

    private void OnMouseDown()
    {
        // Roll the die.
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null && rb.IsSleeping() && playersTurn.AreAllDiceRolled == true && playersTurn.IndividualDiceRollingRemaining > 0)
        {
            rb.velocity += new Vector3(0, Random.Range(6f, 12f), 0);
            rb.angularVelocity += new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));

            playersTurn.GetComponent<PlayersTurn>().IndividualDiceRollingRemaining--;
        }
    }
}
