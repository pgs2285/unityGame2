using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacterUI : MonoBehaviour
{
    public MainCharacter characterData;
    void Update(){
        GetComponent<Image>().sprite = characterData.characterInfo[CharacterData.Instance.mainCh].portrait;
    }

}
