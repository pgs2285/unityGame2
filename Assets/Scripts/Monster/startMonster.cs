using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMonster : Enemy
{
    /* '''
         protected int MaxHP; // monster HP
     protected int currentHP; // monster의 현재 HP
     protected decimal attackDelay; // 몬스터 공격의 딜레이 주기
     protected float moveSpeed; // Monster의 이동속도
     protected int attackPoint; // Enemy공격력
     protected int state; // 0 : 정상상태, 1 : 스턴, 2 : 슬로우 등...

     ''' */
    
    private void Start()
    {
        MaxHP = 3;
        currentHP = 3;
        moveSpeed = 5f;
        attackPoint = 1;
        state = 0;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            CharacterData.Instance.CurrentHP -= attackPoint;
        }else if (collision.collider.CompareTag("PlayerAttack"))
        {
            currentHP -= CharacterData.Instance.AttackPoint;
        }
    }


}
