using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest_open : MonoBehaviour
{
    CircleCollider2D circleCollider2D;
    public SpawnManager spawnManager;
    public GameObject[] chest_item;
     Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("영역안에 들어왔습니다.");
                if(Input.GetKeyUp(KeyCode.Space)){
                    Debug.Log("상자오픈");
                animator.SetTrigger("isOpen");
            }
        }

    }
    public void OnDestroy(){
        

            int random = Random.Range(0, 100);
            if(random < 100){
                //레시피 생성
                Instantiate(Resources.Load("BGMController/Prefabs/apple_1"), transform.position, Quaternion.identity);
            }
            else{}
            spawnManager.EnemyCount--;
    }
}
