using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : Singleton<GameOverController>
{
    GameObject player;
    void Start(){
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
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

    public void GameOverPanel(){
        GameObject.Find("UI").SetActive(false); // UI 비활성화
        Instantiate(Resources.Load("GameOverPanel") as GameObject, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
