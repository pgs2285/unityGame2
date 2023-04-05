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
        int idx = 0;
        foreach (RecipePrefabs recipe in RecipeSystem.Instance.recipeList)
        {
            buttonList[idx].interactable = true;
            buttonList[idx].GetComponent<Image>().sprite = recipe.itemIcon;

            buttonList[idx].GetComponent<RecipeSlot>().recipe = recipe;
            idx++;
        }
    }
}
