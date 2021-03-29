using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class ButtonRollAllDice : MonoBehaviour
{
    [SerializeField] GameObject[] dice;            // Reference to the dice.
    Rigidbody[] rigidBody;                         // Reference to the dice's rigid body.

    [SerializeField] GameObject playersTurnRef;    // Reference to the player's turn.

    private void Start()
    {
        // Get the RigidBody components of the dice.
        rigidBody = new Rigidbody[dice.Length];
        for (int i = 0; i < rigidBody.Length; i++)
        {
            rigidBody[i] = dice[i].GetComponent<Rigidbody>();
        }

        // Get the reference to the player's turn.
        if (playersTurnRef == null)
        {
            playersTurnRef = GameObject.Find("PlayersTurn");
        }
    }

    private void FixedUpdate()
    {
        EnablePassButton();
    }

    public void Roll()
    {
        /*
        // The player can only roll all 6 dice once.
        if (playersTurnRef.GetComponent<PlayersTurn>().AreAllDiceRolled == false)
        {
            // Roll the dice.
            for (int i = 0; i < dice.Length; i++)
            {
                rigidBody[i].velocity += new Vector3(0, Random.Range(6f, 12f), 0);
                rigidBody[i].angularVelocity += new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            }

            playersTurnRef.GetComponent<PlayersTurn>().AreAllDiceRolled = true;
        }
        */

        // Roll the dice.
        for (int i = 0; i < dice.Length; i++)
        {
            rigidBody[i].velocity += new Vector3(0, Random.Range(6f, 12f), 0);
            rigidBody[i].angularVelocity += new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        }

        playersTurnRef.GetComponent<PlayersTurn>().AreAllDiceRolled = true;

        // Disable this button.
        Button button = gameObject.GetComponent<Button>();
        button.interactable = false;       
    }

    // Enable the "Pass" button if the "Roll the Dice" button is pressed and all dice do not move.
    public void EnablePassButton()
    {
        // Check if the "Roll the Dice" is clicked (the button being disabled means that it has been clicked).
        if (gameObject.GetComponent<Button>().interactable == true)
        {
            GameObject.Find("ButtonPass").GetComponent<Button>().interactable = false;
            return;
        }

        // Check if any of the dice are still moving.
        for(int i = 0; i < dice.Length; i++)
        {
            if(!rigidBody[i].IsSleeping())
            {
                GameObject.Find("ButtonPass").GetComponent<Button>().interactable = false;
                return;
            }
        }

        // Enable the "Pass" button.
        GameObject.Find("ButtonPass").GetComponent<Button>().interactable = true;
    }
}
