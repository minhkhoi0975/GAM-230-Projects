using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshCollider))]
public class Shell : MonoBehaviour
{
    public float speed = 30.0f;

    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.position += transform.forward.normalized * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Shell"))
        {
            // If the object is the player's tank, destroy it (don't destroy its parent).
            if(other.CompareTag("Player"))
            {
                Destroy(other.gameObject);
            }

            // If the object is an enemy tank, destroy its parent.
            if (other.CompareTag("Character"))
            {
                Destroy(other.transform.parent.gameObject);
            }

            Debug.Log("Hit an object (" + other.gameObject.name + ").");
            Destroy(gameObject);
        }
    }
}
