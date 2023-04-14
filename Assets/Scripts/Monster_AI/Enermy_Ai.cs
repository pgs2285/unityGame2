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
    int key_ai = 0;
    bool key = true;
    int dir1;
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
            key_ai = 0;
        }
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
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("충돌");
    }
    // Update is called once per frame
    void Update()
    {
        if (key_ai == 1)
        {
            StopCoroutine("RandomMove");
            nav.SetDestination(targetform.position);
            animator.SetBool("iswalk", true);
            once = 0;
        }
        else
        {
            if (once == 0)
            {
                StartCoroutine("RandomMove");
                once = 1;
            }
            else
            {

            }

        }

    }
}