using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear_Management : MonoBehaviour
{
    public GameObject Bear;
    public GameObject rollbear;
    public bool bear_trigger=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bear_trigger==true)
        {
            rollbear.SetActive(false);
            Bear.SetActive(true);
            
        }
        else if(bear_trigger==false)
        {
            Bear.SetActive(false);
            rollbear.SetActive(true);
            
        }
    }
    
}
