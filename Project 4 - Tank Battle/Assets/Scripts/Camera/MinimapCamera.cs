using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public GameObject player;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = player.transform.position - gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Always keep the same distance to the player.
            gameObject.transform.position = player.transform.position - offset;
        }
    }
}
