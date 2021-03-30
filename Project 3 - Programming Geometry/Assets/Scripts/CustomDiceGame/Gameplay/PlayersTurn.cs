/**
 * PlayersTurn.cs
 * Programmer: Khoi Ho
 * Description: This script stores information about the current player's turn.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersTurn : MonoBehaviour
{
    private bool areAllDiceRolled = false;  // Check if all the 6 dice are rolled.
    public bool AreAllDiceRolled { get { return areAllDiceRolled;} set { areAllDiceRolled = value; } }

    private int individualDieRollingRemaining = 3; // How many times left can the player roll an individual die?
    public int IndividualDiceRollingRemaining { get { return individualDieRollingRemaining; } set { individualDieRollingRemaining = (value < 0 ? 0 : value); } }
}
