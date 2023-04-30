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

    void Start()
    {
        currentHp = Hp;
        // prfHpBar = Instantiate(prfHPBar, canvas.transform);
        hpBar = prfHPBar.GetComponent<RectTransform>();
        StartCoroutine(BossPattern());
   
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
            //pattern 2 시작
            secondHpBar.SetActive(true);
        }


    }
    public void animationEnd()
    {
        this.GetComponent<Animator>().SetBool("Hit",false);
    }
    public GameObject Laser;
    public GameObject Laser2;
    IEnumerator BossPattern(){
        yield return new WaitForSeconds(Random.Range(10.0f,15.0f));
        float angle = 0.0f;
        GameObject laserRange = Instantiate(Resources.Load<GameObject>("Prefab/BearLaserRange"));
        yield return new WaitForSeconds(1f);
        Destroy(laserRange);
        while (true){

            Laser.SetActive(true);
            Laser2.SetActive(true);


            
            angle += 2.0f;
            if (angle >= 360.0f)
            {
                angle = 0.0f;
                break;
            }
            Laser.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
            Laser2.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle+180);
            yield return new WaitForFixedUpdate();
        

        }
        Laser2.SetActive(false);
        Laser.SetActive(false);
        StartCoroutine(BossPattern());
        
    }

    
}
