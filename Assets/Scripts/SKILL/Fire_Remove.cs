using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Remove : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("DestroyFire", 3);
        
    }

    // Update is called once per frame
    void Update()
    {       
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (ray.collider != null)
        {
            if (ray.collider.tag == "Enemy")
            {
                ray.collider.GetComponent<Enemy>().TakeDamage(30);
                
            }            
            // ray.collider.GetComponent<Enemy>().Repeat();           
            DestroyFire();
        }
        
    }
    void DestroyFire()
    {
        Destroy(gameObject);
    }
}
