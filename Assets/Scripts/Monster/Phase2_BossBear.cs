using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2_BossBear : MonoBehaviour
{
    Coroutine coroutine;
    Rigidbody2D rgd2D;
    Animator animator;
    private int random;
    int dir1;
    bool istrigger;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        rgd2D=GetComponent<Rigidbody2D>();
        StartCoroutine(Phasetwo_bossbear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Phasetwo_bossbear()
    {
        while(true)
        {
            // random=Random.Range(0,4);
            random=2;
            if(random==0){//idle상태
                animator.SetBool("isattack",false);
                animator.SetBool("iswalk",false);
                animator.SetBool("isrush",false);
            }
            else if(random==1){//공격상태
                animator.SetBool("isattack",true);
                animator.SetBool("iswalk",false);
                animator.SetBool("isrush",false);
            }
            else if(random==2){//걷기상태
                
                phase2_boss_walk();
            }
            else if(random==3){//돌진상태
                animator.SetBool("isattack",false);
                animator.SetBool("iswalk",false);
                animator.SetBool("isrush",true);
            }
            yield return new WaitForSeconds(3.0f);
        }
    }
    void OnCollisionStay2D(Collision2D collider)
    {
        animator.SetBool("iswalk",false);
        int tmp = dir1;
        istrigger=true;
        if (collider.gameObject.CompareTag("Wall"))
        {
            
            dir1 = Random.Range(0, 4);
            while (dir1 == tmp)
            {
                
                phase2_boss_walk();
            }
            Debug.Log("벽에 부딪혔습니다.");
        }
        
    }
    IEnumerator phasetwo_boss_walk(Vector2 dir)
    {
        while(Vector2.Distance(dir,transform.position)>0.1f&&istrigger==false)
        {           
            this.transform.position=Vector2.MoveTowards(this.transform.position,dir,1f*Time.deltaTime);
            yield return new WaitForFixedUpdate();
            animator.SetBool("iswalk",true);
        }
        istrigger=false;
        animator.SetBool("iswalk",false);
        StopCoroutine(coroutine);
        
    }
    void phase2_boss_walk(){
        animator.SetBool("isattack",false);
        animator.SetBool("iswalk",false);
        animator.SetBool("isrush",false);
        dir1=Random.Range(0,4);
        Debug.Log(dir1);
        if (dir1 == 0)
                {
                    Vector2 pos = new Vector2(this.transform.position.x + 1f, this.transform.position.y);
                    coroutine=StartCoroutine(phasetwo_boss_walk(pos));
                }

                else if (dir1 == 1)
                {
                    Vector2 pos = new Vector2(this.transform.position.x - 1f, this.transform.position.y);
                    coroutine=StartCoroutine(phasetwo_boss_walk(pos));
                }
                else if (dir1 == 2)
                {
                    Vector2 pos = new Vector2(this.transform.position.x, this.transform.position.y + 1f);
                    coroutine=StartCoroutine(phasetwo_boss_walk(pos));
                }
                else if (dir1 == 3)
                {
                    Vector2 pos = new Vector2(this.transform.position.x, this.transform.position.y - 1f);
                    coroutine=StartCoroutine(phasetwo_boss_walk(pos));
                }
    }
}
