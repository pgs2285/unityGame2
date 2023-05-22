using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2_Boss_Rush_event : MonoBehaviour
{
    Coroutine coroutine;
    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;
    int random;
    public LayerMask layerMask;
    Animator animator;
    public GameObject BossBear;
    int rush_key = 0;
    public GameObject Bear_management;
    enum rotation
    {
        up=45,
        down=135,
        left=225,
        right=315
    };
    int dir;
    bool end=true;
    int end_key=0;
    // Start is called before the first frame update
    List<int> directions = new List<int> {0, 1, 2, 3};
    void Start()
    {
        
    }
    void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isdrained",false);
        end=true;
        end_key=0;
        directions = new List<int> {0, 1, 2, 3};
        
    }
    private List<T> ShuffleList<T>(List<T> list)
{
    int random1,  random2;
    T temp;

    for (int i = 0; i < list.Count; ++i)
    {
        random1 = Random.Range(0, list.Count);
        random2 = Random.Range(0, list.Count);

        temp = list[random1];
        list[random1] = list[random2];
        list[random2] = temp;
    }

    return list;
}
    
    // Update is called once per frame
    void Update()
    {
        up.SetActive(false);
            down.SetActive(false);
            left.SetActive(false);
            right.SetActive(false);
            if(end_key==0)
            {
                
                directions = ShuffleList(directions);
            }
            
                
                while(end_key<4&&end==true)
                {
                    random = directions[0];
                    directions.RemoveAt(0);
                    if(random==0)
                    {
                        transform.position = new Vector3(-8, 4, 0);// 
                        dir=(int)rotation.up;
                    }
                    else if(random==1){
                        
                        transform.position = new Vector3(7, 1, 0);
                        dir=(int)rotation.down;
                    }
                    else if(random==2){
                        transform.position = new Vector3(6, 10, 0);//
                        dir=(int)rotation.left;
                    }
                    else if(random==3){
                        
                        transform.position = new Vector3(-7, 10, 0);
                        dir=(int)rotation.right;
                    }                         
                    StartCoroutine(Rush((dir)));
                    end=false;
                }
                if(end_key==4)
                {
                    StartCoroutine(Drained());
                }
                else if(end_key>=5){
                    Debug.Log("보스곰 러쉬 끝");
                    
                    // gameObject.SetActive(false);
                    Bear_management.GetComponent<Bear_Management>().bear_trigger=true;
                }
            
    }
    IEnumerator Rush(int dir)
    {
        Bear_management.GetComponent<Bear_Management>().bear_trigger=false;
        float time5=Time.time;
        while(time5-Time.time>-1)
        {
            StartCoroutine(Show_rush_area());
            yield return null;
        }
        transform.eulerAngles = new Vector3(0,0,(int)dir);
        float time=Time.time;
        while(time-Time.time>-2)
        {
            up.SetActive(false);
            down.SetActive(false);
            left.SetActive(false);
            right.SetActive(false);
            animator.SetBool("isdrained",false);
            transform.Translate(Vector2.right*Time.deltaTime*55);
            yield return null;
        }
        end_key++;
        end=true;
    }
    IEnumerator Show_rush_area()
    {
        up.SetActive(false);
        down.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);
        float time3=Time.time;
        while(time3-Time.time>-1)
        {
            if(random==0)//up
            {
                up.SetActive(true);
            }
            else if(random==1)//down
            {
                down.SetActive(true);
            }
            else if(random==2)//left
            {
                left.SetActive(true);
            }
            else if(random==3)//right
            {
                right.SetActive(true);
            }
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator Drained()
    {
        float time2=Time.time;
        int drained_random=Random.Range(0,4);
        transform.rotation=Quaternion.Euler(0,0,0);
        while(time2-Time.time>-4)
        {
            if(drained_random==0)
            {
                animator.SetBool("isdrained",true);
                transform.position=new Vector2(-4,9);
            }
            else if(drained_random==1)
            {
                animator.SetBool("isdrained",true);
                transform.position=new Vector2(2,3);
            }
            else if(drained_random==2)
            {
                animator.SetBool("isdrained",true);
                transform.position=new Vector2(3,9);
            }
            else if(drained_random==3)
            {
                animator.SetBool("isdrained",true);
                transform.position=new Vector2(-3,4);
            }
            yield return null;
        }
        end_key++;
    }
    
}
