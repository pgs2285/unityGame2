using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class stone : MonoBehaviour {
    public float gravity = -9.81f; // 중력 가속도
    public float speed = 10f; // 초기 속도
    public float angle = 130f; // 발사 각도

    

    private Vector3 velocity;

    private void Start() {
        // 초기 속도와 발사 각도에 따라 초기 속도 계산
        angle = Random.Range(100f, 180f);
        float radian = angle * Mathf.PI / 180f;
        float x = speed * Mathf.Cos(radian);
        float y = speed * Mathf.Sin(radian);
        velocity = new Vector3(x, y, 0f);
        Destroy(gameObject, 3f);
    }

    private void FixedUpdate() {
        // 중력 가속도에 따라 속도 갱신
        velocity.y += gravity * Time.fixedDeltaTime;
        transform.position += velocity * Time.fixedDeltaTime;
    }
}
