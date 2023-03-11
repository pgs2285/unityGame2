using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.LightAnchor;

public class JumpSkill : MonoBehaviour
{

    public float jumpDistance = 1.0f;
    public float cooldownTime = 2.0f;
    private bool usableSkill = true;

    private Vector3 jumpDirection = Vector3.zero;
    
    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(X == -1) // 왼쪽 대쉬
            {
                jumpDirection = new Vector3(-jumpDistance, 0,0);
            }else if(X == 1)
            {
                jumpDirection = new Vector3(jumpDistance, 0, 0);
            }
            else if(Y == -1)
            {
                jumpDirection = new Vector3(0, -jumpDistance, 0);
            }
            else if(Y == 1)
            {
                jumpDirection = new Vector3(0, jumpDistance, 0);
            }
            transform.position = transform.position += jumpDirection;
        } 
    }

    private bool isUsable()
    {
        return !usableSkill;
    }
}
