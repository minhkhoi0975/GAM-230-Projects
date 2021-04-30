/**
 * PlayerName.cs
 * Programmer: Khoi Ho
 * Description: This script is attached to the "Enter your name..." input field in the main menu to make sure that the player enters their name before they can start the game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public Button buttonPlay; // Reference to the "Play" button.

    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = GameManager.Instance.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        // If the name is empty, disable the "Play" button.
        if(text.text.Trim() == "")
        {
            buttonPlay.interactable = false;
        }

        // If the name is not empty, update the name in the game manager and enable the "Play" button.
        else
        {
            GameManager.Instance.playerName = text.text.Trim();
            buttonPlay.interactable = true;
        }
    }
}
