using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankOnDestroy : MonoBehaviour
{
    public int score = 500;

    public GameObject debrisPrefab;
    public GameObject explosionPrefab;

    private void OnDestroy()
    {
        /*
        // Create explosion.
        GameObject explosion = Instantiate(gameObject.GetComponent<EnemyTankOnDestroy>().debrisPrefab, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(explosion.gameObject, explosion.GetComponent<ParticleSystem>().main.startLifetime.Evaluate(0.0f));

        // Create debris.
        Instantiate(gameObject.GetComponent<EnemyTankOnDestroy>().debrisPrefab, gameObject.transform.position, gameObject.transform.rotation);
        */
    }
}
