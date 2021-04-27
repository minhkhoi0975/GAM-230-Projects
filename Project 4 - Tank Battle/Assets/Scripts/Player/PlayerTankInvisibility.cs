using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankInvisibility : MonoBehaviour
{
    public float invisibilityTime = 3.0f;
    public GameObject tankChassis;
    public GameObject tankTracksLeft;
    public GameObject tankTracksRight;
    public GameObject tankTurret;

    bool canUseAbility = true;

    public readonly bool isInvisible = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
