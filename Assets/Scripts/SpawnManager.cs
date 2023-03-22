using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;

    public int EnemyCount = 0;
    public int MaxEnemy = 7;

    public float spawnTime = 3f;
    public float curTime;
    private void Update()
    {
        if (curTime >= spawnTime && EnemyCount < MaxEnemy)
        {
            int x = Random.Range(0, spawnPoints.Length);
            SpawnEnemy(x);
        }
        curTime += Time.deltaTime;
    }

    public void SpawnEnemy(int randomEnemy)
    {
        Instantiate(enemy, spawnPoints[randomEnemy]);
        EnemyCount++;
        curTime = 0;
    }

}
