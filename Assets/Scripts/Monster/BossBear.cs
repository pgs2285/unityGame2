using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBear : MonoBehaviour
{
    
    public float Hp = 100;
    public float currentHp=100;

    Rigidbody2D rigidbody2d;
    private float curtime;
    public float cooltime;

    //탄막패턴 변수
    public int bullet_pattern=0;
    public GameObject bullet;
    public Transform bulletPos;
    public int angleinterval=10;
    public int startAngle=30;
    public int endAngle=330;

    public void TakeDamage(float damage)
    {
        currentHp = currentHp - damage;
        Debug.Log(currentHp/Hp);
        hpBar.GetChild(0).GetComponent<Image>().fillAmount = currentHp / Hp;

        this.GetComponent<Animator>().SetBool("hit",true);
        
        
    }
    
    public GameObject prfHPBar;
    public GameObject canvas;
    RectTransform hpBar;
    private GameObject tempObject;

    void Start()
    {
        currentHp = Hp;
        // prfHpBar = Instantiate(prfHPBar, canvas.transform);
        hpBar = prfHPBar.GetComponent<RectTransform>();
        StartCoroutine(BossPattern());
        if(bullet_pattern==0){
            StartCoroutine(bullet_pattern_one());
            
        }
        else if(bullet_pattern==1){
            StartCoroutine(bullet_pattern_two());
        }          
    }

    public float height;
    private void Awake() {
        canvas = GameObject.Find("UI");
    }
    public GameObject secondHpBar;
    void Update()
    {
       
        if (currentHp <= 0)
        {
            Destroy(prfHPBar.gameObject);
            Destroy(gameObject);

        }
      

    }
    public void animationEnd()
    {
        this.GetComponent<Animator>().SetBool("Hit",false);
    }
    public GameObject Laser;

    IEnumerator BossPattern(){
        yield return new WaitForSeconds(Random.Range(10.0f,15.0f));
        float angle = 0.0f;
        GameObject laserRange = Instantiate(Resources.Load<GameObject>("Prefab/BearLaserRange"));
        yield return new WaitForSeconds(1f);
        Destroy(laserRange);
        while (true){

            Laser.SetActive(true);



            
            angle += 2.0f;
            if (angle >= 360.0f)
            {
                angle = 0.0f;
                break;
            }
            Laser.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);

            yield return new WaitForFixedUpdate();
        

        }

        Laser.SetActive(false);
        StartCoroutine(BossPattern());
        
    }
    private IEnumerator bullet_pattern_one(){
        int fireangle=0;
        while(true){
            tempObject=Instantiate(Resources.Load<GameObject>("BGMController/Prefabs/bear_bullet_1"),bulletPos,true);           
            Vector2 dir=new Vector2(Mathf.Cos(fireangle*Mathf.Deg2Rad),Mathf.Sin(fireangle*Mathf.Deg2Rad));
            tempObject.transform.right=dir;
            tempObject.transform.position=transform.position;
            yield return new WaitForSeconds(0.3f);  
            fireangle+=angleinterval;
            if(fireangle>360){
                fireangle-=360;
            }
           
        }
    }
    private IEnumerator bullet_pattern_two(){
        while(true){
            
            for(int fireangle=startAngle;fireangle<endAngle;fireangle+=angleinterval){
                tempObject=Instantiate(Resources.Load<GameObject>("BGMController/Prefabs/bear_bullet_1"),bulletPos,true);
                Vector2 dir=new Vector2(Mathf.Cos(fireangle*Mathf.Deg2Rad),Mathf.Sin(fireangle*Mathf.Deg2Rad));
                tempObject.transform.right=dir;
                tempObject.transform.position=transform.position;
                
            }
            yield return new WaitForSeconds(4f);
        }
    }
    
}
