using System.Collections.Generic;
using UnityEngine;

public class RecipeSystem : Singleton<RecipeSystem>
{
    // 레시피 리스트
    public List<Recipe> recipeList = new List<Recipe>();
    public Item bakedApple;
    // 아이템 리스트


    private void Start()
    {
        // 특정 if 문을 만족하면 "BakedApple" 레시피를 레시피 리스트에 추가합니다.
        if (true) // 여기에 조건을 적어주세요.
        {
            Recipe bakedAppleRecipe = new Recipe("BakedApple", new List<string>() { "Apple", "Touch" }, bakedApple);
            recipeList.Add(bakedAppleRecipe);
        }
    }

    // 레시피를 검사하고, 만약 조건을 충족하면 아이템을 생성합니다.
    private void CheckRecipe()
    {
        int idx = 0;
        foreach (Recipe recipe in recipeList)
        {
            bool canMakeRecipe = true;

            // 레시피에 필요한 아이템들이 모두 있는지 검사합니다.
            foreach (string itemName in recipe.itemNames)
            {
                bool hasItem = false;

                // 아이템 리스트에서 아이템을 찾아서 수량을 검사합니다.
                foreach (Item item in Inventory.instance.itemList)
                {
                    idx ++; 
                    if (item.itemName == itemName)
                    {
                        hasItem = true;
                        if (Inventory.instance.quantityList[idx] < 1)
                        {
                            canMakeRecipe = false;
                            break;
                        }
                    }
                }

                if (!hasItem)
                {
                    canMakeRecipe = false;
                    break;
                }
            }

            // 레시피를 만들 수 있으면 아이템을 생성합니다.
            if (canMakeRecipe)
            {
                foreach (string itemName in recipe.itemNames)
                {
                    RemoveItemFromInventory(itemName);
                }
                AddItemToInventory(recipe.item);
            }
        }
    }

    // 인벤토리에서 아이템을 제거합니다.
    private void RemoveItemFromInventory(string itemName)
    {
        for (int i = 0; i < Inventory.instance.itemList.Count; i++)
        {
            if (Inventory.instance.itemList[i].itemName == itemName)
            {
                Inventory.instance.quantityList[i]--;
                if (Inventory.instance.quantityList[i] <= 0)
                {
                    Inventory.instance.itemList.RemoveAt(i);
                }
                break;
            }
        }
    }

    // 인벤토리에 아이템을 추가합니다.
    private void AddItemToInventory(Item makeditem)
    {
        int idx = 0;
        foreach (Item item in Inventory.instance.itemList)
        {
            idx++;
            if (item.itemName == makeditem.name)
            {
                Inventory.instance.quantityList[idx]++;
                return;
            }
        }
        Inventory.instance.AddItem(makeditem, 1);
    }
}

// 레시피 클래스
public class Recipe
{
    public string resultItemName;
    public List<string> itemNames;
    public Item item;
    public Recipe(string resultItemName, List<string> itemNames, Item item)
    {
        this.resultItemName = resultItemName;
        this.itemNames = itemNames;
        this.item = item;
    }
}

