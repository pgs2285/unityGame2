using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHit : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            CharacterData.Instance.CurrentHP-=1;
        }
    }
}
