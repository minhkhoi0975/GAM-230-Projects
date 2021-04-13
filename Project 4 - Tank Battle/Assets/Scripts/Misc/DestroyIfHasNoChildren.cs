using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfHasNoChildren : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // If this game object has no children, destroy it.
        if(gameObject.transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
