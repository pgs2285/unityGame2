using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMovement : MonoBehaviour
{

    public float speed = 1f;
    public float moveAmount = 1f;

    public bool isOntheLeg = false;
    public Vector3 startPos;
    void Update() {
        // float pingPong = Mathf.PingPong(Time.time * speed, moveAmount * 2) - moveAmount;
        // transform.position = new Vector3(transform.position.x, pingPong, transform.position.z);
    }


    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player is on the leg");
            isOntheLeg = true;
            if(GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("Stun") == false)
            {
                startPos = other.transform.position;    
            }
            
            if(startPos.x > transform.position.x)
            {
                startPos.x += 0.5f;
            }
            else
            {
                startPos.x -= 0.5f;
            }
               
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player"){
            isOntheLeg = false;

        }
    }
}
