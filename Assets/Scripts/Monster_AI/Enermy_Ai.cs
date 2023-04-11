using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enermy_Ai : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent nav;
    public GameObject target;
    [SerializeField] Transform targetform;
    Animator animator;
    float distance;
    public float distanceValue = 3f;
    CircleCollider2D circleCollider2D;
    Rigidbody2D rigidbody2D;
    int time = 1;
    int once = 1;
    int key_ai = 0;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("영역안에 들어왔습니다.");
            key_ai = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int dir1 = Random.Range(0, 4);
            key_ai = 0;
        }
    }

    IEnumerator RandomMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (time < 3 && time > 0)
            {
                time += 1;
                animator.SetBool("iswalk", false);
                Debug.Log("둠칫둠칫");
            }
            else if (time < 4 && time > 3)
            {
                Debug.Log("배회움직임 가동");
                int dir1 = Random.Range(0, 4);
                if (dir1 == 0)
                {

                    rigidbody2D.velocity = new Vector2(1, rigidbody2D.velocity.y);

                }

                else if (dir1 == 1)
                {

                    rigidbody2D.velocity = new Vector2(-1, rigidbody2D.velocity.y);

                }

                else if (dir1 == 2)

                {

                    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 1);

                }

                else if (dir1 == 3)
                {
                    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -1);
                }
                animator.SetBool("iswalk", true);
            }
            else
            {

                time = 1;
                break;
            }
        }


    }
    // Update is called once per frame
    void Update()
    {
        if (key_ai == 1)
        {
            StopCoroutine("RandomMove");
            nav.SetDestination(targetform.position);
            animator.SetBool("iswalk", true);
            once = 1;
        }
        else
        {
            if (once == 1)
            {
                StartCoroutine("RandomMove");
                once++;
            }
            else
            {
                
            }
            
        }

    }
}