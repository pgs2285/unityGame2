using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class closetheDoor : MonoBehaviour
{
    Talk talk;
    void Awake(){

        talk = GameObject.Find("etcController").GetComponent<Talk>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            StartCoroutine(talk.talk(new string[]{"아무래도 저기 앞에있는 곰들은 죽일수 없을거같아","무사히 지나갈 다른방법을 찾아봐야겠어"}));        
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
        }    
    }
}
