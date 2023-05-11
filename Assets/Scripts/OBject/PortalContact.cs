using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalContact : MonoBehaviour
{

    Talk talk;
    void Start(){
        talk = GameObject.Find("etcController").GetComponent<Talk>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            StartCoroutine(talk.talk(new string[]{"지금 이곳에 갈 필요는 없어."}));
        }
    }
}
