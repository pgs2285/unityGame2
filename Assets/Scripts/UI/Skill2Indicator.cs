using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class Skill2Indicator : MonoBehaviour
{
    public MainCharacter mainCharacter;
    public catKeyboard keyboard;

    public TextMeshProUGUI coolTimeIndicator;
    public GameObject panel;
    float leftTime = 0;
    private void Update(){
        
        if(CharacterData.Instance.mainCh == 0){
            leftTime = keyboard.catKCoolTime - keyboard.catkFilledTime;
        }
        else if(CharacterData.Instance.mainCh == 1){
            leftTime = keyboard.foxKCoolTime - keyboard.foxkFilledTime;
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


        this.GetComponent<Image>().sprite = mainCharacter.characterInfo[CharacterData.Instance.mainCh].Skill2Image;
    }
}
