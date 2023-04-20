using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacterUI : MonoBehaviour
{
    MainCharacter characterData;
    void Start(){
        characterData = GameObject.FindWithTag("Player").GetComponent<MainCharacter>();
    }
    void Update(){
        GetComponent<Image>().sprite = characterData.characterInfo[CharacterData.Instance.mainCh].portrait;
    }

}
