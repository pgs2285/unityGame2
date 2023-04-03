using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{   
    [SerializeField]
    private GameObject hpBar;

    // [SerializeField]
    // private TextMeshProUGUI level;
    
    // [SerializeField]
    // private TextMeshProUGUI nowEXP;

    // [SerializeField]
    // private TextMeshProUGUI fullEXP;

    // [SerializeField]
    // private GameObject infoPanel;

    // [SerializeField]
    // private TextMeshProUGUI attackPoint;

    // [SerializeField]
    // private TextMeshProUGUI speed;


    

    private int limitHP=6;


    public void Start(){
        // infoPanel.SetActive(false);
    }
    public void Update(){
        for(int i = 0; i < CharacterData.Instance.CurrentHP; i++){
            hpBar.transform.GetChild(i).gameObject.SetActive(true);
        }
        for(int i = CharacterData.Instance.CurrentHP; i < 4; i++){
            hpBar.transform.GetChild(i).gameObject.SetActive(false);
        }        
        for(int i = 0; i < CharacterData.Instance.Shield; i++){
            hpBar.transform.GetChild(i+4).gameObject.SetActive(true);
        }
        for(int i = CharacterData.Instance.Shield; i < 4; i++){
            hpBar.transform.GetChild(i+4).gameObject.SetActive(false);
        }

        // level.text = CharacterData.Instance.Level.ToString();
        // nowEXP.text = CharacterData.Instance.Experience.ToString();
        // fullEXP.text = CharacterData.Instance.fullExperience[CharacterData.Instance.Level - 1].ToString();

        
    }


    // public void activeExtraInfo(){
    //     if(infoPanel.activeSelf == false){
    //         infoPanel.SetActive(true);
    //         attackPoint.text = CharacterData.Instance.AttackPoint.ToString();
            
    //         speed.text = CharacterData.Instance.Speed.ToString();

    //     }else{
    //         infoPanel.SetActive(false);
    //     }
    // }

    [SerializeField] TextMeshProUGUI chatText;
    GameObject scanObject;
    [SerializeField] GameObject chatPanel;
    public bool isAction = false;
    public int talkIndex;
    public void Action(GameObject scanObj){ //대사 띄워줌

            scanObject = scanObj;
            
            ObjData objData = scanObject.GetComponent<ObjData>();
            talk(objData.id, objData.isNPC);
            chatPanel.SetActive(isAction);

    }

    public TalkManager talkManager;
    public QuestManager questManager;
    
    public void talk(int id, bool isNPC){ //talkManager에 있을 캐릭터의 저장된 대사를 가져옴 
        int questTalkIndex = questManager.getQuestTalkIndex(id);
        string talkData = talkManager.getTalk(id + questTalkIndex, talkIndex);

        if(talkData == null){
            isAction = false;
            talkIndex = 0;
            questManager.checkQuest(id);
            return;
        }
        
        if(isNPC){
            chatText.text = talkData;
        }else{
            chatText.text = talkData;
        }
        talkIndex++;
        isAction = true;

    }


}
