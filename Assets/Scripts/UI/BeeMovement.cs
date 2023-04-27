using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour {
    public Transform player;
    public float speed = 5f;
    public float frequency = 1f;
    public float amplitude = 1f;

    private Vector3 startPosition;
    private float timeOffset;

    void Awake () {
        // Start with a random time offset
        player = GameObject.FindWithTag("Player").transform;
        timeOffset = Random.Range(0f, 100f);
        
        beeAnim = GetComponent<Animator>();
    }
    Animator beeAnim;
    Vector3 direction;
    bool isDeath = false;
    void Update () {
        if(!isDeath){
        direction = player.position - transform.position; // Calculate direction vector towards the player
        float noise = Mathf.PerlinNoise(Time.time * frequency, timeOffset) * 2f - 1f; // Perlin Noise value between -1 and 1
        Vector3 randomDirection = new Vector3(noise, 0f, noise); // Create a random direction vector
        direction += randomDirection * amplitude; // Add the random direction to the current direction vector
        direction = Vector3.ClampMagnitude(direction, 1f); // Limit the magnitude of the direction vector to 1
        transform.position += direction * speed * Time.deltaTime; // Move towards the player
        }else{
            direction = Vector3.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            CharacterData.Instance.CurrentHP-=1;
            Destroy(gameObject.GetComponent<Enemy>().prfHpBar);
            beeAnim.SetTrigger("Death");

            isDeath = true;
        }
        if(other.gameObject.name == "BOSSBEAR"){
            Debug.Log("곰충돌");
            other.gameObject.GetComponent<Enemy>().TakeDamage(10);
            beeAnim.SetTrigger("Death");
            isDeath = true;
        }
    }
}