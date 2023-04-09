using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoxRuneController : MonoBehaviour
{

    public void ShieldSkillEnhance1(){
        if (CharacterData.Instance.RP >= 1) {
            // GetComponentsInParent<Button>()[1].interactable = true;
            // 효과 적어주기
            
            CharacterData.Instance.RP -= 1;
            Debug.Log(gameObject);
            CharacterData.Instance.FoxShieldSkillRuneOpened[0] = true;
            gameObject.SetActive(false);
            
        }
    }

    public void ShieldSkillEnhance2(){
        if (CharacterData.Instance.RP >= 2 && CharacterData.Instance.FoxShieldSkillRuneOpened[0]) {
            // GetComponentsInParent<Button>()[1].interactable = true;
            // 효과 적어주기
            
            CharacterData.Instance.RP -= 2;
            gameObject.SetActive(false);
            CharacterData.Instance.FoxShieldSkillRuneOpened[1] = true;
        }
    }

    public void ShieldSkillEnhance3(){
        if(CharacterData.Instance.RP >= 3 && CharacterData.Instance.FoxShieldSkillRuneOpened[1]){
            // GetComponentsInParent<Button>()[1].interactable = true;
            // 효과 적어주기
            
            CharacterData.Instance.RP -= 3;
            gameObject.SetActive(false);
        }
    }

    public void AttackSkillEnhance1(){
        if (CharacterData.Instance.RP >= 1) {
            // GetComponentsInParent<Button>()[1].interactable = true;
            // 효과 적어주기
            CharacterData.Instance.FoxAttackSkillRuneOpened[0] = true;
            CharacterData.Instance.RP -= 1;
            gameObject.SetActive(false);
        }
    }

    public void AttackSkillEnhance2(){
        if (CharacterData.Instance.RP >= 2 && CharacterData.Instance.FoxAttackSkillRuneOpened[0]) {
            // GetComponentsInParent<Button>()[1].interactable = true;
            // 효과 적어주기
            CharacterData.Instance.FoxAttackSkillRuneOpened[1] = true;
            CharacterData.Instance.RP -= 2;
            gameObject.SetActive(false);
        }
    }

    public void AttackSkillEnhance3(){
        if (CharacterData.Instance.RP >= 3 && CharacterData.Instance.FoxAttackSkillRuneOpened[1]) {
            // GetComponentsInParent<Button>()[1].interactable = true;
            // 효과 적어주기
            CharacterData.Instance.FoxAttackSkillRuneOpened[2] = true;
            CharacterData.Instance.RP -= 3;
            gameObject.SetActive(false);
        }
    }
    public void AttackSkillEnhance4(){
        if (CharacterData.Instance.RP >= 4 && CharacterData.Instance.FoxAttackSkillRuneOpened[2]) {
            // GetComponentsInParent<Button>()[1].interactable = true;
            // 효과 적어주기
            
            CharacterData.Instance.RP -= 4;
            gameObject.SetActive(false);
        }
    }

    public void Arousal(){
        if(CharacterData.Instance.RP >= 10){
            // GetComponentsInParent<Button>()[1].interactable = true;
            // 효과 적어주기
            
            CharacterData.Instance.RP -= 10;
            gameObject.SetActive(false);
        }
    }

}
