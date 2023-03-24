using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    public GameObject rockPrefab; // 돌 프리팹
    public float spawnDelay = 1.0f; // 돌 생성 주기
    public float spawnRadius = 5.0f; // 돌 생성 범위
    
    

    private float spawnTimer = 0.0f; // 돌 생성 타이머

    void Update()
    {
        // 돌 생성 타이머 갱신
        spawnTimer -= Time.deltaTime;

        // 돌 생성 주기마다 돌 생성
        if (spawnTimer <= 0.0f)
        {
            // 돌 생성 위치 계산
            Vector3 spawnPos;
            spawnPos = new Vector3(transform.position.x + (Random.Range(0.0f,1.0f) * spawnRadius), transform.position.y , 0); // 끝에서부터 생성함

            // 돌 생성
            GameObject rock = Instantiate(rockPrefab, spawnPos, Quaternion.identity);


            // 돌 생성 타이머 리셋
            spawnTimer = spawnDelay;
        }
                // 현재 위치에서 fallSpeed 만큼 아래로 이동
        


    }



}
