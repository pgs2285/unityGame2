using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    public float speed = 4.0f;
    public float runSpeed = 6.0f;

    // Update is called once per frame
    void Update()
    {
 
        if(Input.GetKey(KeyCode.LeftShift)){ // 왼
            run(runSpeed);
        }else{
            walk();
        }
    }

    public void walk(){
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(X,Y)*Time.deltaTime*speed);
    }

    public void run(float runSpeed){
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(X,Y)*Time.deltaTime*runSpeed);
    }
}
