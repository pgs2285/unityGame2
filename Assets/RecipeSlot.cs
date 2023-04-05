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
        int idx = 0;
        int idx2 = 0;
        recipeName.text = recipe.itemName;
        List<string> banList = new List<string>();
        foreach(Item item in recipe.ingredients)
        {
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
    public GameObject infoPanel;
    public TextMeshProUGUI[] requireQuantityList;
    public Image[] infoIngredientsImage;
    public void RecipeInfo(){
        
        int idx = 0;
        // infoPanel.SetActive(true);

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


}


