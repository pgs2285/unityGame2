using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catRightClickAttack : MonoBehaviour
{
    public float comboResetTime = 1.0f; // 콤보 리셋 시간
    private float lastAttackTime = 0.0f; // 마지막 공격 시간
    private int comboCount = 0; // 현재 콤보 수
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
 

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || comboCount > 0)
        {
            Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1), 0);

            if (comboCount == 0) lastAttackTime = Time.time; // 처음 들어올때만 찍혀야함
       
            if (Time.time - lastAttackTime < comboResetTime)
            {
                if ( Input.GetMouseButtonDown(0)) comboCount++;
            }
            else
            {
                comboCount = 0;
            }

            

            if (comboCount >= 3)
            {
                comboCount = 0;
            }
            
   
            // 애니메이션 트리거 설정
            animator.SetInteger("ComboCount", comboCount);
        }
    }
}


