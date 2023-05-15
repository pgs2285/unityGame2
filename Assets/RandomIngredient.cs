using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class RandomIngredient : MonoBehaviour
{
    int random;
    public bool isItemObtained = false;
    public Item item;
    GameObject etcController;
    public string[] getConversation;
    public string[] noGetConversation;
    void Start()
    {
        SetItemObtain();
        etcController = GameObject.Find("etcController");
    }
    public void SetItemObtain(){
        random = Random.Range(0, 3); //25%의 확률로 재로가 있음
        if(random == 0){
            isItemObtained = true;
        }else isItemObtained = false;
    }
    public void GetItem(){ // 이게 실행됨
        if(isItemObtained){
            Inventory.instance.AddItem(item, 1);
            StartCoroutine(etcController.GetComponent<Talk>().talk(getConversation));
            GameObject.Find("ItemPanel").GetComponent<Animator>().SetBool("state",true);
            GameObject.Find("ItemName").GetComponent<TextMeshProUGUI>().text = item.itemName;
            GameObject.Find("ItemImage").GetComponent<Image>().sprite = item.itemIcon;
            isItemObtained = false;
        }else{
            StartCoroutine(etcController.GetComponent<Talk>().talk(noGetConversation));
        }
    }

}
