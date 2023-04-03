using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill2Indicator : MonoBehaviour
{
    public MainCharacter mainCharacter;

    private void Update(){
        GetComponent<Image>().sprite = mainCharacter.characterInfo[CharacterData.Instance.mainCh].Skill2Image;
    }
}
