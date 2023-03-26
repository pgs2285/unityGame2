using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneFalling : MonoBehaviour
{
    public float speed = 5f; // 돌이 굴러가는 속도
    public float tumble = 10f; // 돌이 굴러가는 회전 속도

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // 랜덤한 방향으로 돌을 굴립니다.
        Vector2 direction = Quaternion.Euler(0, 0, Random.Range(0f, 360f)) * Vector2.up;

        // Rigidbody2D의 속도를 설정하여 돌을 굴립니다.
        rb.velocity = direction * speed;

        // 돌이 굴러가는 회전 속도를 설정합니다.
        rb.angularVelocity = Random.Range(-tumble, tumble);
    }
}
