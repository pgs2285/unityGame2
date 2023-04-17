using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDown : MonoBehaviour
{
    GameObject movePosition;
    GameObject player;
    IEnumerator  GoDown(){
        player = GameObject.FindWithTag("Player");
        movePosition = transform.GetChild(0).gameObject; // 자식을 가져옴, 자식은 이동 위치를 나타내는 empty 오브젝트
        while(Vector3.Distance(player.transform.position, movePosition.transform.position) > 0.1f){
            player.transform.position = Vector3.MoveTowards(player.transform.position, movePosition.transform.position, 0.1f);
            player.GetComponent<BoxCollider2D>().enabled = false;
            CharacterData.Instance.IsMove = false;
            yield return new WaitForFixedUpdate();
        }
        player.GetComponent<BoxCollider2D>().enabled = true;
        CharacterData.Instance.IsMove = true;
        
    }   

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            StartCoroutine(GoDown());
        }
    }
}
