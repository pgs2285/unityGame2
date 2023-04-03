using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSkillController : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {

        //Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Enemy")
        {
            CharacterData.Instance.FoxSkillStack += 1;
            //Debug.Log("Hit");   

        }

    }

    
}
