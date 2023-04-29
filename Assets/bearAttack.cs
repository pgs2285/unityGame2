using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bearAttack : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            CharacterData.Instance.CurrentHP -= 1;
        }
    }
}
