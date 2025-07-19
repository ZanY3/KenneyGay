using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public int maxEnemies = 10;

    private float timer;
    private int currentCount;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval && currentCount < maxEnemies)
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        currentCount++;
    }
}
