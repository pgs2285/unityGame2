using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class portalManager : MonoBehaviour
{
    public stageManager stage;
    public string sceneName;
    GameObject etcController;
    void Awake()
    {
        etcController = GameObject.Find("etcController");
    }
    private void OnTriggerEnter2D(Collider2D other) {

        Debug.Log("Trigger Enter");
        if(other.gameObject.tag == "Player"){
         
            
            switch(stage){
                case stageManager.stage1:
                

                if(CharacterData.Instance.QuestID < 70){
                    StartCoroutine(etcController.GetComponent<Talk>().talk(new string[]{"아직 여기서 할일이 남아있어."}));
                }else{
                    SceneManager.LoadScene(sceneName);
                }
                break;

                case stageManager.stage2:
                    SceneManager.LoadScene(sceneName);
                break;

                case stageManager.stage3:
                    if(Inventory.instance.itemList.Contains(Resources.Load<Item>("Item/beautifulStone"))){
                        SceneManager.LoadScene(sceneName);
                    }else{
                        StartCoroutine(etcController.GetComponent<Talk>().talk(new string[]{"문이 잠겨있어.", "어디선가 열쇠를 구해야 할거같다."}));
                    }
                break;

                case stageManager.TutorialStage:
                    SceneManager.LoadScene(sceneName);
                    break;
                case stageManager.stage4:
                    SceneManager.LoadScene(sceneName);
                    break;
                case stageManager.BossStage:
                if(GameObject.FindWithTag("Boss") == null)
                    SceneManager.LoadScene(sceneName);
                    break;
            }
        }
    }
}
public enum stageManager{
    stage1,
    stage2,
    stage3,
    stage4,
    TutorialStage
    ,
    BossStage
}