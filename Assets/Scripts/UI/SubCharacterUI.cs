using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SubCharacterUI : MonoBehaviour
{
    MainCharacter characterData;
    public TextMeshProUGUI coolTimeIndicator;
    float leftTime;
    int truncateNumber;
    public GameObject panel;
    void Start(){
        characterData = GameObject.FindWithTag("Player").GetComponent<MainCharacter>();
    }
    void Update(){
        if (CharacterData.Instance.QuestID >= 120)
        {
            GetComponent<Image>().sprite = characterData.characterInfo[CharacterData.Instance.subCh].portrait;


            leftTime = characterData.cooldownTime - characterData.filledTime;
            
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
            
        }
    }

}
