using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swamp : MonoBehaviour
{
    Animator anim;
    void Start(){
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        CharacterData.Instance.Speed -= 1f;   
        anim.SetBool("isSwamp",true);
        CharacterData.Instance.IsAttackAble = false;
    }
    private void OnTriggerExit2D(Collider2D other) {
        CharacterData.Instance.Speed += 1f;
        anim.SetBool("isSwamp",false);
        CharacterData.Instance.IsAttackAble = true;
    }
}
