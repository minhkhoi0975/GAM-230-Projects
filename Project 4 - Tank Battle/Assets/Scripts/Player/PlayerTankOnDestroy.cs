/**
 * PlayerTankOnDestroy.cs
 * Programmer: Khoi Ho (credits to professor Dearbon)
 * Description: This script stores what debris model and explosion effect will be created when the player tank is destroyed.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTankOnDestroy : MonoBehaviour
{
    public GameObject debrisPrefab;
    public GameObject explosionPrefab;
    public AudioClip hitSound;
}
