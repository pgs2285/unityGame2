using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSkill : MonoBehaviour
{
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            
            other.gameObject.GetComponent<Enemy>().TakeDamage(CharacterData.Instance.foxjAttackPoint * CharacterData.Instance.AttackPoint);
            Debug.Log("Hit");   
        }
    }
}
