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
    // Start is called before the first frame update
    void Start()
    {
        rush_key=0;
        currentHp = Hp;
        // prfHpBar = Instantiate(prfHPBar, canvas.transform);
        hpBar = prfHPBar.GetComponent<RectTransform>();
        animator=GetComponent<Animator>();
        rgd2D=GetComponent<Rigidbody2D>();
        StartCoroutine(Phasetwo_bossbear());
    }
    public float height;
    private void Awake() {
        canvas = GameObject.Find("UI");
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
    }
    private IEnumerator Phasetwo_bossbear()//보스곰 상태 머신
    {
        while(true)
        {
            // random=Random.Range(0,4);
            random=Random.Range(0,4);
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
                phase2_boss_rush();
                yield return new WaitForSeconds(9f);
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
        else if(random==3)
        {
            rush_key++;

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
    IEnumerator phasetwo_boss_rush_repeat(Vector2 dir)//돌진 이동 코루틴
    {
        while(Vector2.Distance(dir,transform.position)>0.1f)
        {           
            this.transform.position=Vector2.MoveTowards(this.transform.position,dir,1f*Time.deltaTime);
            yield return new WaitForFixedUpdate();
            animator.SetBool("isrush",true);
        }
        animator.SetBool("isrush",false);
        
    }
    void phase2_boss_walk(){//걷기함수
        animator.SetBool("isattack",false);
        animator.SetBool("iswalk",false);
        animator.SetBool("isrush",false);
        if(collidercheck==false){
            dir1=Random.Range(0,4);
        }        
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
                collidercheck=false;
    }
IEnumerator phasetwo_boss_rush()//돌진 4번돌진 코루틴
    {
        rush_key=0;
        while(rush_key<4)
        {
            if(this.transform.position.x>0&&this.transform.position.y>6)
            {
                if(rush_key==0){                   
                    Vector2 pos=new Vector2(this.transform.position.x-1f,this.transform.position.y-1f);
                    coroutine2=StartCoroutine(phasetwo_boss_rush_repeat(pos));
                    yield return new WaitForSeconds(2f);
                    rush_key++;
                    Debug.Log("1차돌진");
                }
                else if(rush_key==1){                    
                    Vector2 pos=new Vector2(this.transform.position.x+1f,this.transform.position.y-1f);
                    coroutine2=StartCoroutine(phasetwo_boss_rush_repeat(pos));
                    yield return new WaitForSeconds(2f);
                    Debug.Log("2차돌진");
                    rush_key++;
                }
                else if(rush_key==2){
                    Vector2 pos=new Vector2(this.transform.position.x+1f,this.transform.position.y+1f);
                    coroutine2=StartCoroutine(phasetwo_boss_rush_repeat(pos));
                    yield return new WaitForSeconds(2f);
                    Debug.Log("3차돌진");
                    rush_key++;
                }
                else if(rush_key==3){
                    Vector2 pos=new Vector2(this.transform.position.x-1f,this.transform.position.y+1f);
                    coroutine2=StartCoroutine(phasetwo_boss_rush_repeat(pos));
                    yield return new WaitForSeconds(2f);
                    Debug.Log("4차돌진");
                    rush_key++;
                }
            }
            else if(this.transform.position.x<0&&this.transform.position.y>6)
            {
                if(rush_key==0){
                    Vector2 pos=new Vector2(this.transform.position.x+1f,this.transform.position.y-1f);
                    coroutine2=StartCoroutine(phasetwo_boss_rush_repeat(pos));
                    yield return new WaitForSeconds(2f);
                    Debug.Log("1차돌진");
                    rush_key++;
                }
                else if(rush_key==1){
                    Vector2 pos=new Vector2(this.transform.position.x+1f,this.transform.position.y-1f);
                    coroutine2=StartCoroutine(phasetwo_boss_rush_repeat(pos));
                    yield return new WaitForSeconds(2f);
                    Debug.Log("2차돌진");
                    rush_key++;
                }
                else if(rush_key==2){
                    Vector2 pos=new Vector2(this.transform.position.x-1f,this.transform.position.y+1f);
                    coroutine2=StartCoroutine(phasetwo_boss_rush_repeat(pos));
                    yield return new WaitForSeconds(2f);
                    Debug.Log("3차돌진");
                    rush_key++;
                }
                else if(rush_key==3){
                    Vector2 pos=new Vector2(this.transform.position.x-1f,this.transform.position.y+1f);
                    coroutine2=StartCoroutine(phasetwo_boss_rush_repeat(pos));
                    yield return new WaitForSeconds(2f);
                    Debug.Log("4차돌진");
                    rush_key++;
                }
            }
            else if(this.transform.position.x<0&&this.transform.position.y<6)
            {
                if(rush_key==0){
                    Vector2 pos=new Vector2(this.transform.position.x+1f,this.transform.position.y+1f);
                    coroutine2=StartCoroutine(phasetwo_boss_rush_repeat(pos));
                    yield return new WaitForSeconds(2f);
                    Debug.Log("1차돌진");
                    rush_key++;
                }
                else if(rush_key==1){
                    Vector2 pos=new Vector2(this.transform.position.x-1f,this.transform.position.y+1f);
                    coroutine2=StartCoroutine(phasetwo_boss_rush_repeat(pos));
                    yield return new WaitForSeconds(2f);
                    Debug.Log("2차돌진");
                    rush_key++;
                }
                else if(rush_key==2){
                    Vector2 pos=new Vector2(this.transform.position.x-1f,this.transform.position.y-1f);
                    coroutine2=StartCoroutine(phasetwo_boss_rush_repeat(pos));
                    yield return new WaitForSeconds(2f);
                    Debug.Log("3차돌진");
                    rush_key++;
                }
                else if(rush_key==3){
                    Vector2 pos=new Vector2(this.transform.position.x+1f,this.transform.position.y-1f);
                    coroutine2=StartCoroutine(phasetwo_boss_rush_repeat(pos));
                    yield return new WaitForSeconds(2f);
                    Debug.Log("4차돌진");
                    rush_key++;
                }
            }
            else if(this.transform.position.x>0&&this.transform.position.y<6)
            {
                if(rush_key==0){
                    Vector2 pos=new Vector2(this.transform.position.x-1f,this.transform.position.y+1f);
                    coroutine2=StartCoroutine(phasetwo_boss_rush_repeat(pos));
                    yield return new WaitForSeconds(2f);
                    Debug.Log("1차돌진");
                    rush_key++;
                }
                else if(rush_key==1){
                    Vector2 pos=new Vector2(this.transform.position.x+1f,this.transform.position.y+1f);
                    coroutine2=StartCoroutine(phasetwo_boss_rush_repeat(pos));
                    yield return new WaitForSeconds(2f);
                    Debug.Log("2차돌진");
                    rush_key++;
                }
                else if(rush_key==2){
                    Vector2 pos=new Vector2(this.transform.position.x+1f,this.transform.position.y-1f);
                    coroutine2=StartCoroutine(phasetwo_boss_rush_repeat(pos));
                    yield return new WaitForSeconds(2f);
                    Debug.Log("3차돌진");
                    rush_key++;
                }
                else if(rush_key==3){
                    Vector2 pos=new Vector2(this.transform.position.x-1f,this.transform.position.y-1f);
                    coroutine2=StartCoroutine(phasetwo_boss_rush_repeat(pos));
                    yield return new WaitForSeconds(2f);
                    Debug.Log("4차돌진");
                    rush_key++;
                }
            }
            
            Debug.Log("돌진");           
            yield return new WaitForSeconds(2f);
        }
        
    }
    void phase2_boss_rush(){//돌진함수
        rush_key=0;
        animator.SetBool("isattack",false);
        animator.SetBool("iswalk",false);
        animator.SetBool("isrush",false);
        coroutine2=StartCoroutine(phasetwo_boss_rush());
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
