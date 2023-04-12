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

    public GameObject RunePanel;
    bool isRoonPanelActive = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RecipePanel.SetActive(isRecipePanelActive);
            isRecipePanelActive = !isRecipePanelActive;
        }
        if(Input.GetKeyDown(KeyCode.Tab)){
            RunePanel.SetActive(isRoonPanelActive);
            isRoonPanelActive = !isRoonPanelActive;
        }

        if(CharacterData.Instance.QuestID == 80){
            if(Inventory.instance.itemList.Contains(Resources.Load<Item>("Item/AppleSoup"))){
                CharacterData.Instance.QuestID += 10;
            }
        }
    }
}



