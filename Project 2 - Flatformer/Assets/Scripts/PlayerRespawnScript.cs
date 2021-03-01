using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnScript : MonoBehaviour
{
    private GameObject body;
    private GameObject camera;

    private Vector3 initialBodyPosition;
    private Quaternion initialBodyRotation;

    private Vector3 initialCameraPosition;
    private Quaternion initialCameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        body = transform.GetChild(0).gameObject;
        camera = transform.GetChild(1).gameObject;

        initialBodyPosition = body.transform.position;
        initialBodyRotation = body.transform.rotation;

        initialCameraPosition = camera.transform.position;
        initialCameraRotation = camera.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(body.transform.position.y < -25.0f)
        {
            body.transform.position = initialBodyPosition;
            body.transform.rotation = initialBodyRotation;

            camera.transform.position = initialCameraPosition;
            camera.transform.rotation = initialCameraRotation;
        }
    }
}
