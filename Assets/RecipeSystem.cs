using System.Collections.Generic;
using UnityEngine;

public class RecipeSystem : Singleton<RecipeSystem>
{
    // 레시피 리스트
    public List<RecipePrefabs> recipeList = new List<RecipePrefabs>();
    public RecipePrefabs bakedApple;
    // 아이템 리스트

    
    private void Start()
    {
  
        if (true)
        {
            
            recipeList.Add(bakedApple);
            
        }
    }


    public GameObject RecipePanel;
    bool isRecipePanelActive = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RecipePanel.SetActive(isRecipePanelActive);
            isRecipePanelActive = !isRecipePanelActive;
        }
    }
}



