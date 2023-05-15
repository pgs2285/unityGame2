using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoor : MonoBehaviour
{
    Talk talk;


    void Start(){
        talk = GameObject.Find("etcController").GetComponent<Talk>();

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        StartCoroutine(talk.talk(new string[]{"이봐!","여기로 와봐!"}));        
    }
    private void OnTriggerExit2D(Collider2D other) {
        Destroy(gameObject);
    }
}
