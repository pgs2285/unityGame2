using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackRegion : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<Enemy>().TakeDamage(CharacterData.Instance.catjAttackPoint * CharacterData.Instance.AttackPoint);
        }else if(other.gameObject.tag == "Boss"){
            other.gameObject.GetComponent<BossBear>().TakeDamage(CharacterData.Instance.catjAttackPoint * CharacterData.Instance.AttackPoint);
        }
    }
}
