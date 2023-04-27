using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bearAttack : MonoBehaviour
{
    GameObject player;
    private void Awake() {
        player = GameObject.FindWithTag("Player");  
    }
    float attackDelay = 3;
    void Update(){
        if(Vector3.Distance(player.transform.position, transform.position) < 0.5f){
            attackDelay -= Time.deltaTime;
            if(attackDelay < 0){
                GetComponent<Animator>().SetBool("iswalk", false);
                GetComponent<Animator>().SetBool("isattack", true);
                attackDelay = 3;
            }

        }
    }

    void animeReset(){
        GetComponent<Animator>().SetBool("isattack", false);
    }
    
}
