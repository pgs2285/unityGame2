using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float Hp = 100;
    public float currentHp=100;

    Rigidbody2D rigidbody2d;
    private float curtime;
    public float cooltime;
    public void TakeDamage(float damage)
    {
        currentHp = currentHp - damage;
        // HpbarFilled.fillAmount = (float)currentHp / Hp;
        // HpbarBackground.SetActive(true);
        this.GetComponent<Animator>().SetBool("Hit",true);
        hpBar.GetChild(0).GetComponent<Image>().fillAmount = currentHp / Hp;
        
    }
    
    public GameObject prfHPBar;
    public GameObject canvas;
    RectTransform hpBar;
    GameObject prfHpBar;
    void Start()
    {
        currentHp = Hp;
        prfHpBar = Instantiate(prfHPBar, canvas.transform);
        hpBar = prfHpBar.GetComponent<RectTransform>();
   
    }

    public float height;
    void Update()
    {
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * height);
        hpBar.position = _hpBarPos;
        if (currentHp <= 0)
        {
            Destroy(gameObject);
            Destroy(prfHpBar);
        }


    }
    public void animationEnd()
    {
        this.GetComponent<Animator>().SetBool("Hit",false);
    }
}
