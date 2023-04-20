using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;

    public int EnemyCount = 0;
    public int MaxEnemy = 7;
    public int countEnemyDeath = 0;
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

        if(countEnemyDeath >= 10){
            Debug.Log("몬스터를 모두 처치했습니다. 다음 스테이지로 넘어가셍");
            Destroy(GameObject.Find("SpawnPoint"));
            //여기서 막힌문 뚫어주기
        }
    }

    public void SpawnEnemy(int randomEnemy)
    {
        Debug.Log(spawnPoints[randomEnemy].position);

        GameObject _character = Instantiate(enemy, spawnPoints[randomEnemy]);
        _character.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        EnemyCount++;
        curTime = 0;
    }

}
