using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarSkill : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Instantiate(bullet, pos.position, transform.rotation);
        }
    }
}
