using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class RollAllDice : MonoBehaviour
{
    [SerializeField] GameObject[] dice;            // Reference to the dice.
    Rigidbody[] rigidBody;                         // Reference to the dice's rigid body.

    private void Start()
    {
        // Get the RigidBody components of the dice.
        rigidBody = new Rigidbody[dice.Length];
        for(int i = 0; i < rigidBody.Length; i++)
        {
            rigidBody[i] = dice[i].GetComponent<Rigidbody>();
        }
    }

    private void FixedUpdate()
    {
        // Disable the button if the dice are still moving.
        Button button = gameObject.GetComponent<Button>();
        for (int i = 0; i < dice.Length; i++)
        {
            if (!rigidBody[i].IsSleeping())
            {
                
                button.interactable = false;
                return;
            }
        }
        button.interactable = true;
    }

    public void Roll()
    {
        // Roll the dice.
        for (int i = 0; i < dice.Length; i++)
        {
            rigidBody[i].velocity += new Vector3(0, Random.Range(6f, 12f), 0);
            rigidBody[i].angularVelocity += new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        }
    }
}
