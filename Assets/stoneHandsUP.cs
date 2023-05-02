using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneHandsUP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    GameObject Player;
    // Update is called once per frame
    bool isUp = false;
    void Update()
    {
        if(Vector3.Distance(Player.transform.position, transform.position) < 1 && !isUp){
            if(Input.GetKeyDown(KeyCode.Space)){
                isUp = true;
            }
        }    
        else if(isUp){
            transform.position = Player.transform.position + new Vector3(0, 0.5f, 0);
            if(Input.GetKeyDown(KeyCode.Space)){
                isUp = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Portal"){
            isUp = false;
        }
    }
}
