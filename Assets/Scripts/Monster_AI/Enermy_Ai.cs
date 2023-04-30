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
        key_ai = 1;
        targetform = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody2D = GetComponent<Rigidbody2D>();
        nav = GetComponent<NavMeshAgent>();
        nav.updateRotation = false;
        nav.updateUpAxis = false;
        target = GameObject.FindWithTag("Player");
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
                // animator.SetBool("iswalk", false);

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
                // animator.SetBool("iswalk", true);
                // Debug.Log(dir1);

            }
            else
            {

                time = 1;

                key = true;
            }

        }


    }
    float attackDelay = 3;
    bool[] cnt= new bool[4];
    void Update()
    {


        if(!isStun){
            attackDelay -= Time.deltaTime;
            Debug.Log(Vector3.Distance(target.transform.position, transform.position));
            if(gameObject.tag == "Boss" && Vector3.Distance(target.transform.position, transform.position)< 4 && attackDelay < 0){
                animator.SetBool("isattack", true);
            }
            if(Vector3.Distance(target.transform.position, transform.position) < 1 && attackDelay < 0){
                
                
                animator.SetBool("isattack", true);
                Debug.Log("범위안에 들어옴");

            
            }
            else if (key_ai == 1)
            {
                // StopCoroutine("RandomMove");
                Debug.Log("key ai = 1 : iswalk true");
                nav.SetDestination(targetform.position);
                if(target.transform.position.x > transform.position.x){
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }else{
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                animator.SetBool("iswalk", true);
                cnt[0] = true;
            }
            else if(key_ai == 0)
            {
                animator.SetBool("iswalk", false);
            }
        }else{
            // StopCoroutine("RandomMove");
            //transform.position 고정시키기
            transform.position = stunLocation;

            key_ai = 0;
            animator.SetBool("iswalk", false);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

    }
    public Vector2 stunLocation;
    void animeReset(){
        GetComponent<Animator>().SetBool("isattack", false);
        transform.GetChild(1).gameObject.SetActive(false);
        attackDelay = 2;
    }
    void Attack(){
        transform.GetChild(1).gameObject.SetActive(true);
    }


}