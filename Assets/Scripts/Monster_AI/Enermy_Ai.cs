using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enermy_Ai : MonoBehaviour
{
    NavMeshAgent nav;
    public GameObject target;
    [SerializeField] Transform targetform;
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
        key_ai = 0;
        targetform = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody2D = GetComponent<Rigidbody2D>();
        nav = GetComponent<NavMeshAgent>();
        nav.updateRotation = false;
        nav.updateUpAxis = false;
        target = GameObject.Find("Player");
        animator = GetComponent<Animator>();

    }

    IEnumerator RandomMove()
    {

        while (true)
        {

            yield return new WaitForSeconds(0.01f);
            if (time < 200 && time >= 0)
            {
                rigidbody2D.velocity = new Vector2(0, 0);
                time += 1;
                animator.SetBool("iswalk", false);

            }
            else if (time < 300 && time >= 200)
            {

                time += 1;
                if (key)
                {
                    dir1 = Random.Range(0, 4);
                }
                key = false;

                if (dir1 == 0)
                {
                    Vector2 pos = new Vector2(transform.position.x + 0.01f, transform.position.y);
                    transform.position = Vector2.MoveTowards(transform.position, pos, 0.1f);
                }

                else if (dir1 == 1)
                {
                    Vector2 pos = new Vector2(transform.position.x - 0.01f, transform.position.y);
                    transform.position = Vector2.MoveTowards(transform.position, pos, 0.1f);
                }
                else if (dir1 == 2)
                {
                    Vector2 pos = new Vector2(transform.position.x, transform.position.y + 0.01f);
                    transform.position = Vector2.MoveTowards(transform.position, pos, 0.1f);
                }
                else if (dir1 == 3)
                {
                    Vector2 pos = new Vector2(transform.position.x, transform.position.y - 0.01f);
                    transform.position = Vector2.MoveTowards(transform.position, pos, 0.1f);
                }else if(dir1 == 4){ //스턴만을 위한 코드
                    Vector2 pos = new Vector2(transform.position.x, transform.position.y);
                    transform.position = Vector2.MoveTowards(transform.position, pos, 0.1f);
                }
                animator.SetBool("iswalk", true);
                // Debug.Log(dir1);

            }
            else
            {

                time = 1;

                key = true;
            }

        }


    }

    void Update()
    {
        Debug.Log(key_ai + "진행방향" );
        if(!isStun){

            if (key_ai == 1)
            {
                // StopCoroutine("RandomMove");
                nav.SetDestination(targetform.position);
                animator.SetBool("iswalk", true);
                once = 0;
            }
            else
            {
                if (once == 0)
                {
                    // StartCoroutine("RandomMove");
                    once = 1;
                }

            }
        }else{
            // StopCoroutine("RandomMove");
            //transform.position 고정시키기
            transform.position = stunLocation;

            key_ai = 0;
            animator.SetBool("iswalk", false);
        }

    }
    public Vector2 stunLocation;
}