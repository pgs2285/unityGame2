using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSkillController : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {

        //Debug.Log(other.gameObject.tag);
        if(other.CompareTag("Enemy"))
        {
            CharacterData.Instance.FoxSkillStack ++;
            other.gameObject.GetComponent<Enemy>().TakeDamage(CharacterData.Instance.catkAttackPoint * CharacterData.Instance.AttackPoint);
            Debug.Log("Hit");   

        }
        

    }

    
}
