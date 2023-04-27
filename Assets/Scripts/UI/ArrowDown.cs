using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDown : MonoBehaviour
{
    GameObject movePosition;
    GameObject player;
    IEnumerator  GoDown(GameObject objects){
        player = GameObject.FindWithTag("Player");
        movePosition = transform.GetChild(0).gameObject; // 자식을 가져옴, 자식은 이동 위치를 나타내는 empty 오브젝트
        while(Vector3.Distance(objects.transform.position, movePosition.transform.position) > 0.05f){
            objects.transform.position = Vector3.MoveTowards(objects.transform.position, movePosition.transform.position, 0.3f);
            objects.GetComponent<BoxCollider2D>().enabled = false;
            CharacterData.Instance.IsMove = false;

            yield return new WaitForFixedUpdate();
        }

        objects.GetComponent<BoxCollider2D>().enabled = true;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        CharacterData.Instance.IsMove = true;
        
    }   
    Animator anim;
    void Awake(){
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetBool("hold", true);
        StartCoroutine(GoDown(other.gameObject));
    }
    void endAnim(){
        anim.SetBool("hold", false);
    }
}
