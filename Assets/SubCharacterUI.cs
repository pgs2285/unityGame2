using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubCharacterUI : MonoBehaviour
{
    public MainCharacter characterData;
    void Update(){
        if(CharacterData.Instance.QuestID >= 80)
        GetComponent<Image>().sprite = characterData.characterInfo[CharacterData.Instance.subCh].portrait;
    }

}
