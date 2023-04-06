using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class RuneController : MonoBehaviour
{
    void Awake(){
        
    }
    
    
    public void RuneAttack1(){
        if (CharacterData.Instance.RP >= 1) {
            Debug.Log(GetComponentInParent<Button>().name);
            GetComponentsInParent<Button>()[1].interactable = true;
            // 효과 적어주기
            
            CharacterData.Instance.RP -= 1;
            gameObject.SetActive(false);
        }
    }
}
