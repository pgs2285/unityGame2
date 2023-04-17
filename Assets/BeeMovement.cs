using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeeMovement : MonoBehaviour {
     public Transform player;
    public float speed = 5f;
    public float frequency = 1f;
    public float amplitude = 1f;

    private Vector3 startPosition;
    private float timeOffset;

    void Start () {
        startPosition = transform.position;
        timeOffset = Random.Range(0f, 100f); // Start with a random time offset
    }

    void Update () {
        Vector3 direction = player.position - transform.position; // Calculate direction vector towards the player
        float noise = Mathf.PerlinNoise(Time.time * frequency, timeOffset) * 2f - 1f; // Perlin Noise value between -1 and 1
        Vector3 randomDirection = new Vector3(noise, 0f, noise); // Create a random direction vector
        direction += randomDirection * amplitude; // Add the random direction to the current direction vector
        direction = Vector3.ClampMagnitude(direction, 1f); // Limit the magnitude of the direction vector to 1
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f); // Check if there is an obstacle in the way
        if (!hit.collider || hit.collider.gameObject == player.gameObject) {
            transform.position += direction * speed * Time.deltaTime; // Move towards the player
        }
    }
}