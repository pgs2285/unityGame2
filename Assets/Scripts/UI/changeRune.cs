using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeRune : MonoBehaviour
{

    public Image portrait;
    public GameObject FoxRune;
    public GameObject CatRune;

    int[] characters = new int[2];
    int idx = 0;
    public void ChangeRune(){
        characters[0] = CharacterData.Instance.mainCh;
        characters[1] = CharacterData.Instance.subCh;
        
        if(idx == 1){
            portrait.sprite = Resources.Load<Sprite>("fox");
            FoxRune.SetActive(true);
            CatRune.SetActive(false);
            
            idx = characters[0];
        }
        else if (idx == 0){
            portrait.sprite = Resources.Load<Sprite>("cat");
            FoxRune.SetActive(false);
            CatRune.SetActive(true);
            
            idx = characters[1];
        }
    }
}
