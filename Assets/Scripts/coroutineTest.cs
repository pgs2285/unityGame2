using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutineTest : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        MaxHP = 10;
        currentHP = 10;
        attackDelay = 100m;
        moveSpeed = 2.0f;
        attackPoint = 1;
        state = 0;

        Debug.Log("MaxHP : " + MaxHP + " currentHP : " + currentHP + " attackDelay : " + attackDelay + "moveSpeed : " + moveSpeed + " attackPoint : " + attackPoint + " state : " + state);
        StartCoroutine(getStun(2.0f));
        Debug.Log("°á°ú \n MaxHP : " + MaxHP + " currentHP : " + currentHP + " attackDelay : " + attackDelay + "moveSpeed : " + moveSpeed + " attackPoint : " + attackPoint + " state : " + state);
    }

    

    
}
