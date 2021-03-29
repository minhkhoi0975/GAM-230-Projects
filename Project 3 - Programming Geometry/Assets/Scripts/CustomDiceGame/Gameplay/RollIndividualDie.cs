using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollIndividualDie : MonoBehaviour
{
    // Reference to the player's turn
    GameObject playersTurnRef;

    // Start is called before the first frame update
    void Start()
    {
        playersTurnRef = GameObject.Find("PlayersTurn");
    }

    private void OnMouseDown()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null && rb.IsSleeping() && playersTurnRef.GetComponent<PlayersTurn>().AreAllDiceRolled == true && playersTurnRef.GetComponent<PlayersTurn>().IndividualDiceRollingRemaining > 0)
        {
            rb.velocity += new Vector3(0, Random.Range(6f, 12f), 0);
            rb.angularVelocity += new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));

            playersTurnRef.GetComponent<PlayersTurn>().IndividualDiceRollingRemaining--;
        }
    }
}
