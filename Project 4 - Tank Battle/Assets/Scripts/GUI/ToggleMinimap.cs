/**
 * ToggleMinimap.cs
 * Programmer: Khoi Ho
 * Description: This script allows the player to toggle/untoggle the minimap.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ToggleMinimap : MonoBehaviour
{
    RawImage minimap;

    // Start is called before the first frame update
    void Start()
    {
        minimap = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("ToggleMinimap"))
        {
            minimap.enabled = !minimap.enabled;
        }
    }
}
