using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_M : MonoBehaviour
{

    protected int MaxHP; // monster HP
    protected int currentHP; // monster�� ���� HP
    protected decimal attackDelay; // ���� ������ ������ �ֱ�
    protected float moveSpeed; // Monster�� �̵��ӵ�
    protected int attackPoint; // Enemy���ݷ�
    protected int state; // 0 : �������, 1 : ����, 2 : ���ο� ��...

    protected int giveDamage()
    {
        return attackPoint; // attackPoint 1�� ��Ʈ ��ĭ���� ������ 
    }

    protected IEnumerator getStun(float time) // ���Ͻð� ����  StartCoroutine���� ���
    {

            
            float tmp_speed = moveSpeed;
            decimal tmp_attackDelay = attackDelay; // ���� ������ 
            moveSpeed = 0;
            attackDelay = 100000m;
            Debug.Log("���� ����");
            Debug.Log("MaxHP : " + MaxHP + " currentHP : " + currentHP + " attackDelay : " + attackDelay + "moveSpeed : " + moveSpeed + " attackPoint : " + attackPoint + " state : " + state);
            yield return new WaitForSeconds(time); // time �ʸ�ŭ ������
            moveSpeed = tmp_speed;
            attackDelay = tmp_attackDelay;//������ �ٽ� ����
            Debug.Log("��������");
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
