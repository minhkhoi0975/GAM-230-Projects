using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static int collectibleCount = 0;

    public int score = 100;

    private void Awake()
    {
        collectibleCount++;
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0.0f, 60.0f * Time.deltaTime, 0.0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.currentLevelScore += score;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        collectibleCount--;
    }
}
