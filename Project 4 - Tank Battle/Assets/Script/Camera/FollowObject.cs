using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject target; // Which object does this camera look at?

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.transform.position - gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Always keep the same distance to the target.
        gameObject.transform.position = target.transform.position - offset;

        // Always look at the target.
        gameObject.transform.LookAt(target.transform);
    }
}
