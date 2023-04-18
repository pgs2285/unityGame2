using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyBEE : MonoBehaviour
{


    IEnumerator beeGenerate(){
        yield return new WaitForSeconds(0.5f);
        GameObject bee = Instantiate(Resources.Load("Prefab/bee"),transform.position + new Vector3(1, Random.Range(-1.0f,1.0f),0), Quaternion.identity) as GameObject;

    }
    float time;
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            // 스페이스를 5초간 누르고 있으면 벌 1마리 소환?
            if(Input.GetKey(KeyCode.Space)){
                Debug.Log(time);
                time += Time.deltaTime;
                if(time >= 5.0f){
                    StartCoroutine(beeGenerate());
                    
                    time = 0;
                }
            }

        }
    }
}

/*
public class RandomMovement : MonoBehaviour {
    public float speed = 3f;
    public float frequency = 1f;
    public float amplitude = 1f;

    private Vector3 startPosition;
    private float timeOffset;

    void Start () {
        startPosition = transform.position;
        timeOffset = Random.Range(0f, 100f); // Start with a random time offset
    }

    void Update () {
        float noise = Mathf.PerlinNoise(Time.time * frequency, timeOffset) * 2f - 1f; // Perlin Noise value between -1 and 1
        Vector3 direction = new Vector3(noise, 0f, noise); // Create a random direction vector
        direction = Vector3.ClampMagnitude(direction, 1f); // Limit the magnitude of the direction vector to 1
        NavMeshHit hit;
        if (NavMesh.SamplePosition(startPosition + direction * amplitude, out hit, 1f, NavMesh.AllAreas)) {
            transform.position = Vector3.MoveTowards(transform.position, hit.position, speed * Time.deltaTime); // Move towards the new position
        }
    }
}


*/