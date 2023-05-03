using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddRecipes : MonoBehaviour
{
    public GameObject recipeSlots;
    Button[] buttonList;

    // List<string> recipeIconList = new List<string>();

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
            buttonList[idx].GetComponent<Image>().sprite = Resources.Load("Image/RecipeIcon/" + recipe.name, typeof(Sprite)) as Sprite;
            Debug.Log("Image/RecipeIcon/" + recipe.name);

            buttonList[idx].GetComponent<RecipeSlot>().recipe = recipe;
            idx++;
        }
    }
}
