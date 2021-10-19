using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyGO;
    public GameObject bossGO;
    private float changedSpawnTime = 5f;
    private float maxSpawnTime = 1f;

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject enemy = Instantiate(enemyGO);
        enemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        SheduleNextSpawn();
    }
    void SheduleNextSpawn()
    {
        float currentSpawnTime;
        if (changedSpawnTime > maxSpawnTime)
            currentSpawnTime = Random.Range(1f, changedSpawnTime);
        else
            currentSpawnTime = maxSpawnTime;
        Invoke("SpawnEnemy", currentSpawnTime);
    }
    void IncreaseSpawn()
    {
        if (changedSpawnTime > maxSpawnTime)
            changedSpawnTime--;
        if (changedSpawnTime == maxSpawnTime)
            CancelInvoke("IncreaseSpawn");
    }

    public void StopSpawn()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawn");
        CancelInvoke("SpawnBoss");
    }
    public void StartSpawn()
    {
        changedSpawnTime = 5f;
        float increasingSpawnTime = 30f;
        float spawnBossTime = 10f;
        Invoke("SpawnEnemy", changedSpawnTime);
        InvokeRepeating("IncreaseSpawn", 0f, increasingSpawnTime);
        InvokeRepeating("SpawnBoss", 0f, spawnBossTime);
    }

    public void SpawnBoss()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject boss = Instantiate(bossGO);
        boss.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    }

}
