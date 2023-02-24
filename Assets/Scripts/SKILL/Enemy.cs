using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int Hp = 100;
    public int currentHp=100;
    public GameObject HpbarBackground;
    public Image HpbarFilled;
    Rigidbody2D rigidbody2d;
    private float curtime;
    public float cooltime;
    public void TakeDamage(int damage)
    {
        currentHp = currentHp - damage;
        HpbarFilled.fillAmount = (float)currentHp / Hp;
        HpbarBackground.SetActive(true);
        Debug.Log(currentHp);
    }
    public IEnumerator KeepDamage()
    {
        curtime = cooltime;
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log(curtime);
            TakeDamage(30);
            if (curtime <= 0)
            {
                break;
            }
            curtime-=1;
        }       
    }
    public void Repeat()
    {
        StartCoroutine("KeepDamage");
    }
    public void Stop()
    {
        StopCoroutine("KeepDamage");
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHp = Hp;
        rigidbody2d = GetComponent<Rigidbody2D>();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
