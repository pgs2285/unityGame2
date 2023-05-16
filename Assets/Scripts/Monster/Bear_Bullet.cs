using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear_Bullet : MonoBehaviour
{
    private Rigidbody2D rgd2D;
    private float speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        rgd2D = GetComponent<Rigidbody2D>();
        rgd2D.velocity = speed*transform.right;
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
