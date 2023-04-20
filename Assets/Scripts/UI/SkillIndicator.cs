using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class SkillIndicator : MonoBehaviour
{
    MainCharacter mainCharacter;
    catKeyboard keyboard;

    public TextMeshProUGUI coolTimeIndicator;
    public GameObject panel;
    float leftTime = 0;
    void Start(){
        mainCharacter = GameObject.FindWithTag("Player").GetComponent<MainCharacter>();
        keyboard= GameObject.FindWithTag("Player").GetComponent<catKeyboard>();
    }
    private void Update(){
        
        if(CharacterData.Instance.mainCh == 0){
            leftTime = keyboard.catJCoolTime - keyboard.catjFilledTime;
        }
        else if(CharacterData.Instance.mainCh == 1){
            leftTime = keyboard.foxJCoolTime - keyboard.foxjFilledTime;
        }
        
        if (leftTime > 0.2)
        {
            coolTimeIndicator.text = Math.Truncate((leftTime * 100) / 100).ToString();
            panel.SetActive(true);
        }
        else
        {
            coolTimeIndicator.text = " ";
            panel.SetActive(false);
        }


        gameObject.GetComponent<Image>().sprite = mainCharacter.characterInfo[CharacterData.Instance.mainCh].Skill1Image;
        
    }
}
