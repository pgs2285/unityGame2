using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest_monster_ai : MonoBehaviour
{
    Animator animator;
    float distance;
    public float distanceValue = 3f;
    CircleCollider2D circleCollider2D;
    Rigidbody2D rigidbody2D;
    int time = 1;
    int once = 0;
    public int key_ai = 0;
    bool key = true;
    int dir1;
    public bool isStun = false;
    // Start is called before the first frame update

    void Start()
    {
        // key_ai = 1;
        rigidbody2D = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("영역안에 들어왔습니다.");
            animator.SetBool("isFake",true);
            animator.SetBool("isAttack",true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isAttack",false);
        }
    }
    float attackDelay = 3;
    bool[] cnt= new bool[4];
    void Update()
    {
        if(!isStun){
            attackDelay -= Time.deltaTime;
            
            // if(gameObject.tag == "Boss" && Vector3.Distance(target.transform.position, transform.position)< 4 && attackDelay < 0){
            //     animator.SetBool("isattack", true);
            // }
            
            
        }else{
            // StopCoroutine("RandomMove");
            //transform.position 고정시키기
            transform.position = stunLocation;

            
            
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

    }
    public Vector2 stunLocation;
    void animeReset(){
        GetComponent<Animator>().SetBool("isAttack", false);
        transform.GetChild(1).gameObject.SetActive(false);
        attackDelay = 2;
    }
    void Attack(){
        transform.GetChild(1).gameObject.SetActive(true);
    }
}
