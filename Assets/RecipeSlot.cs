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

    public void RecipeClick()
    {
        int idx = 0;
        recipeName.text = recipe.itemName;
        foreach(Item item in recipe.ingredients)
        {
            ingredientsList[idx].sprite = item.itemIcon;
            idx++;

        }

    }    
}


