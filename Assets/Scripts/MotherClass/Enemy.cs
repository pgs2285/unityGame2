using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected int MaxHP; // monster HP
    protected int currentHP; // monster의 현재 HP
    protected decimal attackDelay; // 몬스터 공격의 딜레이 주기
    protected float moveSpeed; // Monster의 이동속도
    protected int attackPoint; // Enemy공격력
    protected int state; // 0 : 정상상태, 1 : 스턴, 2 : 슬로우 등...

    protected int giveDamage()
    {
        return attackPoint; // attackPoint 1당 하트 반칸으로 가정함 
    }

    protected IEnumerator getStun(float time) // 스턴시간 추후  StartCoroutine으로 사용
    {

            
            float tmp_speed = moveSpeed;
            decimal tmp_attackDelay = attackDelay; // 변수 저장후 
            moveSpeed = 0;
            attackDelay = 100000m;
            Debug.Log("스턴 시작");
            Debug.Log("MaxHP : " + MaxHP + " currentHP : " + currentHP + " attackDelay : " + attackDelay + "moveSpeed : " + moveSpeed + " attackPoint : " + attackPoint + " state : " + state);
            yield return new WaitForSeconds(time); // time 초만큼 기절후
            moveSpeed = tmp_speed;
            attackDelay = tmp_attackDelay;//이전값 다시 저장
            Debug.Log("스턴해제");
            Debug.Log("MaxHP : " + MaxHP + " currentHP : " + currentHP + " attackDelay : " + attackDelay + "moveSpeed : " + moveSpeed + " attackPoint : " + attackPoint + " state : " + state);

    }

    protected IEnumerator getSlow(float time, float rate) // coroutine
    {

            float tmp_speed = moveSpeed;
            moveSpeed = moveSpeed * rate;
            yield return new WaitForSeconds(time);
            moveSpeed = tmp_speed;

        
    }
}
