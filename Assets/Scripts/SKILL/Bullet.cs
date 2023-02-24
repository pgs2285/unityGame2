using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullets;
    public Transform bulletpos;
    public float cooltime;
    private float curtime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (curtime <= 0)
        {
            if (Input.GetKey(KeyCode.X))
            {
                Instantiate(bullets, bulletpos.position, transform.rotation);
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }
    
}
