﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class RecipeSystem : Singleton<RecipeSystem>
{
    // 레시피 리스트
    public List<RecipePrefabs> recipeList = new List<RecipePrefabs>();
    public RecipePrefabs bakedApple;
    // 아이템 리스트
    Scene scene;
    GameObject normalWorldObject;
    GameObject anotherWorldObject;
    GameObject normalWorldGround;
    GameObject anotherWorldGround;
    public GameObject anotherWorldEffect;

    private void Start()
    {
        recipeList.Add(bakedApple);

        try{
        
            scene = SceneManager.GetActiveScene();
            normalWorldGround = GameObject.Find("normalWorld");
            normalWorldObject = GameObject.Find("normalWorldObject");
            anotherWorldGround = GameObject.Find("anotherWorld");
            anotherWorldObject = GameObject.Find("anotherWorldObject");
            anotherWorldGround.SetActive(false);
            anotherWorldObject.SetActive(false);
        }catch(System.Exception e){
            Debug.Log(e);
        }
        fox = GameObject.Find("FOX");
        questManager = GameObject.Find("QuestManager").GetComponent<QuestManager>();
    }
    private GameObject fox;
    QuestManager questManager;

    public GameObject RecipePanel;
    bool isRecipePanelActive = false;

    public GameObject RunePanel;
    public GameObject InfoPanel;
    bool isRoonPanelActive = false;
    bool world = true;
    private void Update()
    {
   
        // if(Input.GetKeyDown(KeyCode.Tab)){
        //     RunePanel.SetActive(isRoonPanelActive);
        //     isRoonPanelActive = !isRoonPanelActive;
        // }
        RecipePanel = GameObject.Find("UI").transform.GetChild(0).gameObject;
        InfoPanel = GameObject.Find("UI").transform.GetChild(1).gameObject;
        switch(CharacterData.Instance.QuestID){
            case 40:
                if(Inventory.instance.itemList.Contains(Resources.Load<Item>("Item/AppleSoup"))){
                    CharacterData.Instance.QuestID += 10;
                    try{
                        Destroy(questManager.questState);
                        questManager.questState = Instantiate(Resources.Load("QuestState/QuestStartOrEnd") as GameObject, new Vector2(fox.transform.position.x + 0.5f, fox.transform.position.y +0.8f), Quaternion.identity);
                    }catch(Exception e){

                    }
                }
                break;
            
            case 50:
                if(GameObject.Find("Fence").transform.childCount == 0){ //모두 부서져 있으면
                    CharacterData.Instance.QuestID += 10;
                    Debug.Log("퀘스트 60으로 변경");
                    Destroy(questManager.questState);
                    questManager.questState = Instantiate(Resources.Load("QuestState/QuestStartOrEnd") as GameObject, new Vector2(fox.transform.position.x + 0.5f, fox.transform.position.y +0.8f), Quaternion.identity);

                }
            break;
            case 80:
                if(Inventory.instance.itemList.Contains(Resources.Load<Item>("Item/goldRecipe"))){
                    CharacterData.Instance.QuestID += 10;
                }
            break;

        }


        if(scene.name =="4 bearCave"){
            if(Input.GetKeyDown(KeyCode.LeftShift)){
                if(world){
                    normalWorldGround.SetActive(true);
                    normalWorldObject.SetActive(true);
                    anotherWorldGround.SetActive(false);
                    anotherWorldObject.SetActive(false);
                    // anotherWorldEffect.SetActive(false);
                }else{
                    anotherWorldGround.SetActive(true);
                    anotherWorldObject.SetActive(true);
                    // anotherWorldEffect.SetActive(true);
                    normalWorldGround.SetActive(false);
                    normalWorldObject.SetActive(false);
                }
                world = !world;

                
            }
        }
    }

}



