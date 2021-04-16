using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankOnDestroy : MonoBehaviour
{
    public GameObject debrisPrefab;
    public GameObject explosionPrefab;

    private void OnDestroy()
    {
        // Create explosion.
        //GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        //Destroy(explosion.gameObject, explosion.GetComponent<ParticleSystem>().main.startLifetime.Evaluate(0.0f));

        // Create debris.
        //GameObject debris = Instantiate(debrisPrefab, transform.position, transform.rotation);
        //Destroy(debris, 5.0f);
    }
}
