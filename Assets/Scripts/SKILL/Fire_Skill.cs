using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Skill : MonoBehaviour
{
    public GameObject fire;
    public Transform firepos;
    public float cooltime_fire;
    private float curtime_fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curtime_fire <= 0)
        {
            if (Input.GetKey(KeyCode.C))
            {
                Instantiate(fire, firepos.position, transform.rotation);
            }
            curtime_fire = cooltime_fire;
        }
        curtime_fire -= Time.deltaTime;
    }

}
