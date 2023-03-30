using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class catRightClickAttack : MonoBehaviour
{
    private Animator animator;
    private float lastAttackTime;
    private int attackCount;

    public float comboTime = 1.0f;
    public float attackRange = 1.5f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastAttackTime < comboTime && attackCount < 3)
            {
                attackCount++;
                animator.SetBool("isAttacking", true);
            }
            else
            {
                attackCount = 1;
                animator.SetInteger("attackCount", attackCount);
                animator.SetBool("isAttacking", true);
            }

            lastAttackTime = Time.time;
        }

        if (Time.time - lastAttackTime >= comboTime && animator.GetBool("isAttacking"))
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

