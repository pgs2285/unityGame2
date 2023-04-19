using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliff : MonoBehaviour
{

    public GameObject onTheLeg;
    public Animator player;

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && !onTheLeg.GetComponent<LegMovement>().isOntheLeg)
        {
            Debug.Log("Player Fall from the leg");
            player.SetBool("Stun", true);
            CharacterData.Instance.IsMove = false;


            
        }
    }
}
