using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistPattern : MonoBehaviour
{
    Animator anim;
    public Camera cam;
    GameObject player;
    GameObject target;
    Coroutine pistMovement;
    void Start(){
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        cam.GetComponent<CameraFollow>().player = gameObject.transform;
  


    }
    int cnt = 0;
    void AnimeEnd(){
        if(cnt < 3){
            anim.SetTrigger("Entrance");
            StartCoroutine(Shake(0.5f, 2.0f));
            
        }

    }
    Vector3 direction;
    public float speed = 5f;
    public float frequency = 1f;
    public float amplitude = 1f;
    private float timeOffset;
    IEnumerator attack(){
        while(true){
            
            yield return new WaitForFixedUpdate();
            direction = (player.transform.position + new Vector3(0f, 5f, 0f)) - transform.position; // Calculate direction vector towards the player
            float noise = Mathf.PerlinNoise(Time.time * frequency, timeOffset) * 2f - 1f; // Perlin Noise value between -1 and 1
            Vector3 randomDirection = new Vector3(noise, 0f, noise); // Create a random direction vector
            direction += randomDirection * amplitude; // Add the random direction to the current direction vector
            direction = Vector3.ClampMagnitude(direction, 1f); // Limit the magnitude of the direction vector to 1
            transform.position += direction * speed * Time.deltaTime ; // Move towards the player

        }
    }
    public float yOffset = 5.0f;   
    bool oneTime = true;
    public IEnumerator Shake(float _amount, float _duration)
    {
        float timer = 0;
        Vector3 originPos = cam.transform.localPosition;
        while (timer <= _duration)
        {
            cam.transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        cnt++;
        if(cnt >= 2 && oneTime)
        {
            cam.GetComponent<CameraFollow>().player = player.transform;
            pistMovement = StartCoroutine(attack());
            smash = StartCoroutine(Smash());
            oneTime = false;

        }

    }
    Coroutine smash;
    IEnumerator Smash(){
        while(true){
            yield return new WaitForSeconds(Random.Range(3f, 8f));
            
            Vector3 Target = transform.position - new Vector3(0,5f,0);
            StopCoroutine(pistMovement);
            
            GameObject attackRange = Instantiate(Resources.Load("Prefab/BearPistRange") as GameObject,Target,Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            GetComponent<BoxCollider2D>().enabled = true;
            StartCoroutine(Shake(0.3f, 1f));
            while(Vector3.Distance(transform.position, Target) > 0.05){
                Debug.Log("내려찍기" + transform.position);
                transform.position = Vector3.Lerp(transform.position, Target, 0.2f);
                yield return new WaitForFixedUpdate();
            }
            GameObject smashCrask = Instantiate(Resources.Load("Resources/Prefab/particle_crack.prefab") as GameObject,transform.position,Quaternion.identity);
            Target = transform.position + new Vector3(0,5f,0);
            while(Vector3.Distance(transform.position, Target) > 0.01f){
                transform.position = Vector3.Lerp(transform.position, Target, 0.2f);
                yield return new WaitForFixedUpdate();
            }
            Destroy(smashCrask);

            GetComponent<BoxCollider2D>().enabled = false;

            Destroy(attackRange);

            pistMovement = StartCoroutine(attack());

        }
    }
        private void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.tag == "Player"){
                CharacterData.Instance.CurrentHP-=1;
            }
        }
    }


