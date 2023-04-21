using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

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
    int count = 0;
    public TextMeshProUGUI countDownText;
    private void Start()
    {
        recipeList.Add(bakedApple);
            
        
        scene = SceneManager.GetActiveScene();
        normalWorldGround = GameObject.Find("normalWorld");
        normalWorldObject = GameObject.Find("normalWorldObject");
        anotherWorldGround = GameObject.Find("anotherWorld");
        anotherWorldObject = GameObject.Find("anotherWorldObject");
        anotherWorldGround.SetActive(false);
        anotherWorldObject.SetActive(false);
    }
    IEnumerator countDown(){
        while(count <= 10){
        yield return new WaitForSeconds(1f);
        count ++;     
        }

    }


    public GameObject RecipePanel;
    bool isRecipePanelActive = false;

    public GameObject RunePanel;
    bool isRoonPanelActive = false;
    bool world = true;
    Coroutine countdownCoroutine ;
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

        switch(CharacterData.Instance.QuestID){
            case 80:
                if(Inventory.instance.itemList.Contains(Resources.Load<Item>("Item/AppleSoup"))){
                    CharacterData.Instance.QuestID += 10;
                }
                break;
            
            case 100:
                if(GameObject.Find("Fence").transform.childCount == 0){ //모두 부서져 있으면
                    CharacterData.Instance.QuestID += 10;
                }
            break;

        }


        if(scene.name =="4 bearCave"){
            if(Input.GetKeyDown(KeyCode.LeftShift) && world){
        
 

                anotherWorldGround.SetActive(true);
                anotherWorldObject.SetActive(true);
                anotherWorldEffect.SetActive(true);
                normalWorldGround.SetActive(false);
                normalWorldObject.SetActive(false);
                world =false;
                
               
                countdownCoroutine = StartCoroutine(countDown());
                
            }
            else{ //여기가 사후세카이

            }
            if(count >= 10){
                count = 0;
                world = true;
                normalWorldGround.SetActive(true);
                normalWorldObject.SetActive(true);
                anotherWorldGround.SetActive(false);
                anotherWorldObject.SetActive(false);
                anotherWorldEffect.SetActive(false);
                countDownText.text = "";
                StopCoroutine(countdownCoroutine);

            }else{
                countDownText.text = (10 - count).ToString();
            }
        }
    }



}



