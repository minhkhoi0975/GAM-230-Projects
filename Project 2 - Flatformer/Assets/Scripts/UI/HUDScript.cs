/**
 * HUDScript.cs
 * Description: This script handles the HUD.
 * Programmer: Khoi Ho
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    [SerializeField] private GameObject timer;   // Reference to the timer of the scene.

    private Text textCoinsCollected;
    private Text textTimer;

    // Start is called before the first frame update
    void Start()
    {
        textCoinsCollected = transform.GetChild(0).gameObject.GetComponent<Text>();
        textTimer = transform.GetChild(1).gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Display the number of collected coins.
        textCoinsCollected.text = "Coins Collected: " + GameManagerScript.Instance.CoinsCollected;

        // Display the timer.
        int seconds = (int)timer.GetComponent<TimerScript>().TimeLeft;
        int minutes = seconds / 60;
        seconds = seconds % 60;
        textTimer.text = "Time Left: " + minutes + "m" + seconds + "s";
    }
}
