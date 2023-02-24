using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;
    Skill skill;
    Vector2 Dir;
    Vector2 Abs;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", 2);
        skill = GameObject.Find("kkamnyang").GetComponent<Skill>();
        Dir = new Vector2(skill.point.x - skill.position.x, skill.point.y - skill.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position,transform.right,distance,isLayer);
        if (ray.collider != null)
        {
            if (ray.collider.tag == "Enemy")
            {
                ray.collider.GetComponent<Enemy>().TakeDamage(10);

            }
            DestroyBullet();
        }

        Dir = new Vector2(skill.point.x-skill.position.x, skill.point.y-skill.position.y);
        if (Dir.y < 0)
        {
            Abs.y = Dir.y * -1;
        }
        else
        {
            Abs.y = Dir.y;
        }
        if (Dir.x < 0)
        {
            Abs.x=Dir.x * -1;   
        }
        else
        {
            Abs.x = Dir.x;
        }
        Debug.Log("Dir.x : "+Dir.x.ToString()+"Dir.y : "+Dir.y.ToString()+"Abs.y"+Abs.y.ToString());
        if (Abs.y > Abs.x)
        {
            if (Dir.y > 0)
            {
                transform.Translate(transform.up*speed*Time.deltaTime);
                Debug.Log("위쪽입니다");
            }
            else
            {
                transform.Translate(transform.up * -1*speed * Time.deltaTime);
                Debug.Log("아래쪽입니다");
            }
        }
        else
        {
            if (Dir.x > 0)
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
                Debug.Log("오른쪽입니다");
            }
            else
            {
                transform.Translate(transform.right * -1 * speed * Time.deltaTime);
                Debug.Log("왼쪽입니다");
            }
        }
      
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
