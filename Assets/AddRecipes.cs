using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddRecipes : MonoBehaviour
{
    public GameObject recipeSlots;
    Button[] buttonList;

    private void Start()
    {
         buttonList = recipeSlots.GetComponentsInChildren<Button>();
    }

    private void Update()
    {
        foreach (Recipe recipe in RecipeSystem.Instance.recipeList)
        {
            Debug.Log(recipe.item.itemIcon);
            buttonList[0].GetComponent<Image>().sprite = recipe.item.itemIcon;
        }
    }
}
