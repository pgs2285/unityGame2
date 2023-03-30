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
            if (Time.time - lastAttackTime < comboResetTime && Input.GetMouseButtonDown(0))
            {
                comboCount++;
            }


            if (comboCount > 3)
            {
                comboCount = 0;
            }

            lastAttackTime = Time.time;
            Debug.Log(comboCount);
            // 애니메이션 트리거 설정
            animator.SetInteger("ComboCount", comboCount);
        }
    }
}


