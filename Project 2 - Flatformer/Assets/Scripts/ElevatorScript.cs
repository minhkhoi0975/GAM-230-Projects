using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public Transform position1;
    public Transform position2;

    private float t = 0.0f;
    private float direction = 1.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(position1.position, position2.position, t);

        t += direction * Time.deltaTime / 1;

        if(t <= 0.0f || t >= 1.0f)
        {
            direction = -direction;
        }
    }
}
