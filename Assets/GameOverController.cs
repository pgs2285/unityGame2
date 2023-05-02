using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : Singleton<GameOverController>
{
    GameObject player;
    void Start(){

    }

    void Update()
    {
        player = GameObject.FindWithTag("Player");
        if(CharacterData.Instance.CurrentHP <= 0){
            CharacterData.Instance.IsMove = false;
            player.GetComponent<Animator>().SetTrigger("isDead");
            Debug.Log("Game Over");
        }

        if(CharacterData.Instance.Hungry <= 0){
            Debug.Log("Game Over");
            player.GetComponent<Animator>().SetTrigger("isDead");
        }
    }


}
