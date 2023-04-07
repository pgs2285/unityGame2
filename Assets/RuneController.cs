using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class RuneController : MonoBehaviour
{
    public void RuneAttack1(){
        if (CharacterData.Instance.RP >= 1) {
            // GetComponentsInParent<Button>()[1].interactable = true;
            // 효과 적어주기
            
            CharacterData.Instance.RP -= 1;
            gameObject.SetActive(false);
            CharacterData.Instance.IsAttackRuneOpened[0] = true;
        }
    }

    public void RuneAttack2(){
        if (CharacterData.Instance.RP >= 2 && CharacterData.Instance.IsAttackRuneOpened[0]) {
            // GetComponentsInParent<Button>()[1].interactable = true;
            // 효과 적어주기
            
            CharacterData.Instance.RP -= 2;
            gameObject.SetActive(false);
            CharacterData.Instance.IsAttackRuneOpened[1] = true;
        }
    }

    public void RuneAttack3(){
        if(CharacterData.Instance.RP >= 3 && CharacterData.Instance.IsAttackRuneOpened[1]){
            // GetComponentsInParent<Button>()[1].interactable = true;
            // 효과 적어주기
            
            CharacterData.Instance.RP -= 3;
            gameObject.SetActive(false);
        }
    }

    public void RuneSpeed1(){
        if (CharacterData.Instance.RP >= 1) {
            // GetComponentsInParent<Button>()[1].interactable = true;
            // 효과 적어주기
            CharacterData.Instance.IsSpeedRuneOpened[0] = true;
            CharacterData.Instance.RP -= 1;
            gameObject.SetActive(false);
        }
    }

    public void RuneSpeed2(){
        if (CharacterData.Instance.RP >= 2 && CharacterData.Instance.IsSpeedRuneOpened[0]) {
            // GetComponentsInParent<Button>()[1].interactable = true;
            // 효과 적어주기
            CharacterData.Instance.IsSpeedRuneOpened[1] = true;
            CharacterData.Instance.RP -= 2;
            gameObject.SetActive(false);
        }
    }

    public void RuneSpeed3(){
        if (CharacterData.Instance.RP >= 3 && CharacterData.Instance.IsSpeedRuneOpened[1]) {
            // GetComponentsInParent<Button>()[1].interactable = true;
            // 효과 적어주기
            CharacterData.Instance.IsSpeedRuneOpened[2] = true;
            CharacterData.Instance.RP -= 3;
            gameObject.SetActive(false);
        }
    }
    public void RuneSpeed4(){
        if (CharacterData.Instance.RP >= 4 && CharacterData.Instance.IsSpeedRuneOpened[2]) {
            // GetComponentsInParent<Button>()[1].interactable = true;
            // 효과 적어주기
            
            CharacterData.Instance.RP -= 4;
            gameObject.SetActive(false);
        }
    }

    public void CoolTimeDown(){
        if(CharacterData.Instance.RP >= 5){
            // GetComponentsInParent<Button>()[1].interactable = true;
            // 효과 적어주기
            
            CharacterData.Instance.RP -= 5;
            gameObject.SetActive(false);
        }
    }


}



