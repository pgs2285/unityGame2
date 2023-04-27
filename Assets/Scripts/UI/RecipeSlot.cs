using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class RecipeSlot : MonoBehaviour
{
    
    public RecipePrefabs recipe;

    public TextMeshProUGUI recipeName;
    public Image[] ingredientsList;
    public TextMeshProUGUI[] inventoryQuantityList;
    
    public void RecipeClick()
    {
        // recipe = Resources.Load<RecipePrefabs>("Recipe/" + EventSystem.current.currentSelectedGameObject.name);
        int idx = 0;
        int idx2 = 0;
        
        GameObject button = GameObject.Find("MakeButton");
        button.GetComponent<RecipeSlot>().recipe = recipe;

        recipeName.text = recipe.itemName;
        for(int i = 0; i< inventoryQuantityList.Length; i++){
            inventoryQuantityList[i].text = "0";
        }
        List<string> banList = new List<string>();
        foreach(Item item in recipe.ingredients)
        {
            idx2= 0;
            if(banList.Contains(item.itemName))
                continue;
            ingredientsList[idx].sprite = item.itemIcon;

            foreach(Item item2 in Inventory.instance.itemList){
                
                if(item == item2)    
                {

                    inventoryQuantityList[idx].text = Inventory.instance.quantityList[idx2].ToString();


                    
                }
                idx2++;
            }

            banList.Add(item.itemName);
            idx++;

        }


    } 


    public TextMeshProUGUI[] requireQuantityList;
    public Image[] infoIngredientsImage;
    public TextMeshProUGUI Description;
    public void RecipeInfo(){
        
        int idx = 0;

        Description.text = recipe.Description;
        
        List<string> banList = new List<string>();



        foreach(Item item in recipe.ingredients)
        {
            if(banList.Contains(item.itemName))
                continue;
            infoIngredientsImage[idx].GetComponent<Image>().sprite = item.itemIcon;
            int count = new List<Item>(recipe.ingredients).FindAll(x => x.itemName == item.itemName).Count;

            requireQuantityList[idx].text = count.ToString();
            banList.Add(item.itemName);
            idx++;
        }

    }

    public void MakeItem(){
        int idx = 0; 

        for(int i = 0; i< inventoryQuantityList.Length; i++){
            if(int.Parse(inventoryQuantityList[i].text) >= int.Parse(requireQuantityList[i].text)){ // 두개 순회하며 비교하기
                idx++;
                // Debug.Log(inventoryQuantityList[i].text + " <--(inventory) (require)--> " + requireQuantityList[i].text);
            }else{
                return; 
            } // pass
        }
        int ingridientCount = 0;

        for(int i = 0; i < requireQuantityList.Length;i++){ // 중간중간 0인 허수를 제거한다.
        
            if(requireQuantityList[i].text == "0")
                continue;
            else ingridientCount ++;
        }
        int inventoryCount = Inventory.instance.itemList.Count;
            Debug.Log("레시피"+ recipe.itemName+ "만들기, 필요 재료 개수"  +ingridientCount + "개");
            for(int i = 0; i< ingridientCount; i++){
                Debug.Log("레시피"+ recipe.itemName+ "만들기, 필요 재료"  + recipe.ingredients[i].itemName);
                for(int j = 0; j< inventoryCount; j++){
                    try{

                        Debug.Log(Inventory.instance.itemList[j].itemName + " <--(inventory) (require)--> " + recipe.ingredients[i].itemName);
                        if(Inventory.instance.itemList[j].itemName == recipe.ingredients[i].itemName){
                        Inventory.instance.quantityList[j] -= int.Parse(requireQuantityList[i].text);
                        // Debug.Log("재료 소모 후 재료 개수" + Inventory.instance.quantityList[j]);
                        if(Inventory.instance.quantityList[j] == 0){
                            Inventory.instance.itemList.RemoveAt(j);
                            Inventory.instance.quantityList.RemoveAt(j);
                        }
                    }

                    }catch{

                    }   

                }

            }
        Inventory.instance.AddItem(recipe,1);
        RecipeClick();
    }
    
}


