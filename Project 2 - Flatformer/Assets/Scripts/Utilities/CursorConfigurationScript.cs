/**
 * CursorConfigurationScript.cs
 * Description: This script allows the game developer to lock the cursor to the center and hide the cursor.
 * Programmer: Khoi Ho
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorConfigurationScript : MonoBehaviour
{
    [SerializeField] bool isCursorLocked = false;
    [SerializeField] bool isCursorHidden = false;

    // Start is called before the first frame update
    void Start()
    {
        if (isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

        Cursor.visible = !isCursorHidden;
    }
}
