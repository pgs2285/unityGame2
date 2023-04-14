using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getItem : MonoBehaviour
{
    
    public void Get(){
        Inventory.instance.AddItem(Resources.Load<Item>("Item/" + gameObject.name),1);
        switch(gameObject.name){
            case "Torch":
                if(CharacterData.Instance.QuestID == 70){
                    CharacterData.Instance.QuestID+= 10;
                }
            break;
        }
        Destroy(gameObject);
    }
}
