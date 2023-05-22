using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Phase2_BossBear : MonoBehaviour
{
    public float Hp = 100;
    public float currentHp=100;
    Coroutine coroutine;
    Coroutine coroutine2;
    Rigidbody2D rgd2D;
    Animator animator;
    private int random;
    int dir1;
    bool collidercheck=false;
    bool istrigger;
    public GameObject prfHPBar;
    public GameObject canvas;
    RectTransform hpBar;
    public int rush_key=0;
    public GameObject rollBear;
    public GameObject Bear_management;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    public float height;
    private void Awake() {
        canvas = GameObject.Find("UI");
    }


    void OnEnable()
    {

        if(rush_key==0)
        {
            currentHp = Hp;
            // prfHpBar = Instantiate(prfHPBar, canvas.transform);
            hpBar = prfHPBar.GetComponent<RectTransform>();
            animator=GetComponent<Animator>();
            rgd2D=GetComponent<Rigidbody2D>();         
        }  
        // if(coroutine2==null)     
          coroutine2=StartCoroutine(Phasetwo_bossbear());
          Bear_management.GetComponent<Bear_Management>().bear_trigger=true;
            
    }
    public GameObject secondHpBar;
    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0)
        {
            Destroy(prfHPBar.gameObject);
            Destroy(gameObject);

        }
        Bear_management.GetComponent<Bear_Management>().bear_trigger=true;
        
    }
    public IEnumerator Phasetwo_bossbear()//보스곰 상태 머신
    {
        while(true)
        {
            Debug.Log("보스곰 상태머신");
            Debug.Log(random);
            // random=Random.Range(0,4);
            random=Random.Range(0,5);
            if(random==0){//idle상태
                animator.SetBool("isattack",false);
                animator.SetBool("iswalk",false);
                animator.SetBool("isrush",false);
                gameObject.transform.GetChild(3).gameObject.SetActive(false);
                Bear_management.GetComponent<Bear_Management>().bear_trigger=true;
            }
            else if(random==1){//공격상태
                animator.SetBool("isattack",true);
                animator.SetBool("iswalk",false);
                animator.SetBool("isrush",false);
                gameObject.transform.GetChild(3).gameObject.SetActive(false);
                Bear_management.GetComponent<Bear_Management>().bear_trigger=true;
            }
            else if(random==2){//걷기상태
                phase2_boss_walk();
                Bear_management.GetComponent<Bear_Management>().bear_trigger=true;
            }
            else if(random==3){//돌진상태
                rush_key++;
                Debug.Log("돌진상태");
                // rollBear.SetActive(true);
                Bear_management.GetComponent<Bear_Management>().bear_trigger=false;
                
                
            }
            else if(random==4)
            {
                animator.SetBool("isattack",false);
                animator.SetBool("iswalk",false);
                animator.SetBool("isrush",false);
                Bear_management.GetComponent<Bear_Management>().bear_trigger=true;
                gameObject.transform.GetChild(3).gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(1.5f);
        }
    }
    void OnCollisionEnter2D(Collision2D collider)//벽 충돌시 이동 방향전환
    {
        int tmp;
        
        if(random==2){
            animator.SetBool("iswalk",false);
            tmp = dir1;
            istrigger=true;
            if (collider.gameObject.CompareTag("Wall"))
            {
                try
                {
                    StopCoroutine(coroutine);
                }
                catch (System.Exception)
                {
                    
                    Debug.Log("코루틴이 없습니다.");
                }
                
            }
        }       
    }
    
    IEnumerator phasetwo_boss_walk(Vector2 dir)//기본걷기 코루틴
    {
        while(Vector2.Distance(dir,transform.position)>0.1f&&istrigger==false)
        {           
            this.transform.position=Vector2.MoveTowards(this.transform.position,dir,1f*Time.deltaTime);
            yield return new WaitForFixedUpdate();
            animator.SetBool("iswalk",true);
        }
        istrigger=false;
        animator.SetBool("iswalk",false);
        try
        {
            StopCoroutine(coroutine);
        }
        catch (System.Exception)
        {
            
            Debug.Log("코루틴이 없습니다.");
        }
        
        
    }
    void phase2_boss_walk(){//걷기함수
        animator.SetBool("isattack",false);
        animator.SetBool("iswalk",false);
        animator.SetBool("isrush",false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        if(collidercheck==false){
            dir1=Random.Range(0,4);
        }        
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
                collidercheck=false;
    }
    public void phase_two_idle_attack(){//기본공격 콜리더 활성화
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }
    public void phase_two_idle_attack_end(){//기본공격 콜리더 비활성화
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
    public void phase_two_rush_attack(){//돌진공격 콜리더 활성화
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }
    public void phase_two_rush_attack_end(){//돌진공격 콜리더 비활성화
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }
    public void TakeDamage(float damage)
    {
        currentHp = currentHp - damage;
        Debug.Log(currentHp/Hp);
        hpBar.GetChild(0).GetComponent<Image>().fillAmount = currentHp / Hp;

        this.GetComponent<Animator>().SetBool("hit",true);
        
        
    }
    
}
