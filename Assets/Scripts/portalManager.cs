using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class portalManager : MonoBehaviour
{
    public stageManager stage;
    public string sceneName;
    GameObject etcController;
    GameObject fadeInPanel;
    void Awake()
    {
        etcController = GameObject.Find("etcController");
        fadeInPanel = GameObject.Find("Fade");
    }

    IEnumerator FadeIn(string sceneName){
        fadeInPanel.GetComponent<Image>().color = new Color(0,0,0,0);
        while(fadeInPanel.GetComponent<Image>().color.a < 1){
            fadeInPanel.GetComponent<Image>().color += new Color(0,0,0,0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene(this.sceneName);
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Player"){
         
            
            switch(stage){
                case stageManager.stage1:
                

                if(CharacterData.Instance.QuestID < 80){
                    StartCoroutine(etcController.GetComponent<Talk>().talk(new string[]{"아직 여기서 할일이 남아있어."}));
                }else{
                    StartCoroutine(FadeIn(sceneName));
                }
                break;

                case stageManager.stage2:
                    StartCoroutine(FadeIn(sceneName));
                break;

                case stageManager.stage3:
                    if(Inventory.instance.itemList.Contains(Resources.Load<Item>("Item/beautifulStone"))){
                        StartCoroutine(FadeIn(sceneName));
                    }else{
                        StartCoroutine(etcController.GetComponent<Talk>().talk(new string[]{"문이 잠겨있어.", "어디선가 열쇠를 구해야 할거같다."}));
                    }
                break;

                case stageManager.TutorialStage:
                    StartCoroutine(FadeIn(sceneName));
                    break;
                case stageManager.stage4:
                    StartCoroutine(FadeIn(sceneName));
                    break;
                case stageManager.BossStage:
                if(GameObject.FindWithTag("Boss") == null)
                    StartCoroutine(FadeIn(sceneName));
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