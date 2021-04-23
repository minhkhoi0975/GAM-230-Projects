using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int numberOfEnemies = 5;
    public float spawnDelayInSeconds = 5.0f;

    bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canSpawn && numberOfEnemies > 0)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(enemy, transform);
        numberOfEnemies--;

        canSpawn = false;
        yield return new WaitForSeconds(spawnDelayInSeconds);
        canSpawn = true;
    }
}
