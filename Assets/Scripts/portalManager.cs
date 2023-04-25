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
        switch(stage){
            case stageManager.stage1:
            

            if(CharacterData.Instance.QuestID < 70){
                StartCoroutine(etcController.GetComponent<Talk>().talk(new string[]{"아직 여기서 할일이 남아있어."}));
            }else{
                SceneManager.LoadScene(sceneName);
            }
            break;
        }
    }
}
public enum stageManager{
    stage1,
    stage2,
    stage3,
    stage4
}