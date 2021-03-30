/**
 * ScoreCalculator.cs
 * Programmer: Khoi Ho
 * Description: This script calculates the score the players gains from the 6 dice.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    private int score = 0;
    public int Score { get { return score; } }

    PlayersTurn playersTurnRef; // Reference to the player's turn.

    [SerializeField] GameObject[] dice; // Refernce to the dice. The first two dices are tetrahedral, the next ones are cubic, and the last ones are octahedral.
    Rigidbody[] rigidBody; // Reference to the dice's rigid body.


    // Start is called before the first frame update
    void Start()
    {
        playersTurnRef = GameObject.Find("PlayersTurn").GetComponent<PlayersTurn>();
        
        // Get the RigidBody components of the dice.
        rigidBody = new Rigidbody[dice.Length];
        for (int i = 0; i < rigidBody.Length; i++)
        {
            rigidBody[i] = dice[i].GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If the dice are still moving, set score to 0.
        for (int i = 0; i < dice.Length; i++)
        {
            if (!rigidBody[i].IsSleeping())
            {
                score = 0;
                return;
            }
        }

        int sum = 0;
        int pairsWithSameNumberCount = 0;

        // Get the value of each die.
        int tetrahedralDieValue1 = dice[0].GetComponent<Tetrahedron>().diceValue;
        int tetrahedralDieValue2 = dice[1].GetComponent<Tetrahedron>().diceValue;
        int cubicDieValue1 = dice[2].GetComponent<Cube>().diceValue;
        int cubicDieValue2 = dice[3].GetComponent<Cube>().diceValue;
        int octahedralDieValue1 = dice[4].GetComponent<Octahedron>().diceValue;
        int octahedralDieValue2 = dice[5].GetComponent<Octahedron>().diceValue;

        // If the two tetrahedral dice have the same number, their sum is doubled.
        if (tetrahedralDieValue1 == tetrahedralDieValue2)
        {
            sum += (tetrahedralDieValue1 + tetrahedralDieValue2) * 2;
            pairsWithSameNumberCount++;
        }
        else
        {
            sum += tetrahedralDieValue1 + tetrahedralDieValue2;
        }

        // If the two cubic dice have the same number, their sum is multiplied by 4. 
        if (cubicDieValue1 == cubicDieValue2)
        {
            sum += (cubicDieValue1 + cubicDieValue2) * 4;
            pairsWithSameNumberCount++;
        }
        else
        {
            sum += cubicDieValue1 + cubicDieValue2;
        }

        // If the two octahdedral dice have the same number, their sum is multiplied by 6.
        if (octahedralDieValue1 == octahedralDieValue2)
        {
            sum += (octahedralDieValue1 + octahedralDieValue2) * 6;
            pairsWithSameNumberCount++;
        }
        else
        {
            sum += octahedralDieValue1 + octahedralDieValue2;
        }

        // 50 points is added to the overall score if there are two pairs of same-shape dice that have the same values in each pair.
        if(pairsWithSameNumberCount == 2)
        {
            sum += 50;
        }
        // 100 points is added to the overall score if all the pairs of same-shape dice that have the same values in each pair.
        else if (pairsWithSameNumberCount == 3)
        {
            sum += 100;
        }

        score = sum;
        if (playersTurnRef.AreAllDiceRolled == true)
        {
            Debug.Log(score + "(T" + tetrahedralDieValue1 + "-T" + tetrahedralDieValue2 + "-C" + cubicDieValue1 + "-C" + cubicDieValue2 + "-O" + octahedralDieValue1 + "-O" + octahedralDieValue2 + ")");
        }
    }

    // Show the numbers of the dice.
    public string showDiceInfo()
    {
        int tetrahedralDieValue1 = dice[0].GetComponent<Tetrahedron>().diceValue;
        int tetrahedralDieValue2 = dice[1].GetComponent<Tetrahedron>().diceValue;
        int cubicDieValue1 = dice[2].GetComponent<Cube>().diceValue;
        int cubicDieValue2 = dice[3].GetComponent<Cube>().diceValue;
        int octahedralDieValue1 = dice[4].GetComponent<Octahedron>().diceValue;
        int octahedralDieValue2 = dice[5].GetComponent<Octahedron>().diceValue;

        return "T" + tetrahedralDieValue1 + "-T" + tetrahedralDieValue2 + "-C" + cubicDieValue1 + "-C" + cubicDieValue2 + "-O" + octahedralDieValue1 + "-O" + octahedralDieValue2;
    }
}
