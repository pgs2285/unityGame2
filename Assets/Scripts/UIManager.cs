using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
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
        talkManager = GameObject.Find("TalkMgr").GetComponent<TalkManager>();
        questManager = GameObject.Find("QuestManager").GetComponent<QuestManager>();
        HPBar = GameObject.Find("HP");
    }


    GameObject HPBar;
    public void Update(){
        for(int i =0; i<8;i++){
            HPBar.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/null");
        }
        for(int i = 0; i < CharacterData.Instance.MaxHP; i++){
            HPBar.transform.GetChild(i/2).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/EmptyHP");
        }
        for(int i =0; i < CharacterData.Instance.CurrentHP; i++){
            
            HPBar.transform.GetChild(i/2).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/FullHP");
            if(CharacterData.Instance.CurrentHP % 2 == 1){
                HPBar.transform.GetChild(CharacterData.Instance.CurrentHP/2).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/HalfHP");
            }
            if(CharacterData.Instance.Shield > 0){
                for(int j = 0; j < CharacterData.Instance.Shield; j++){
                    HPBar.transform.GetChild(CharacterData.Instance.CurrentHP/2+j/2 + 1).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/FullShield");
                    if(CharacterData.Instance.Shield % 2 == 1){
                        HPBar.transform.GetChild(CharacterData.Instance.Shield/2).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/HalfShield");
                    }
                }
            }
        }
        
    }


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

    TalkManager talkManager;
    QuestManager questManager;
    
    public void talk(int id, bool isNPC){ //talkManager에 있을 캐릭터의 저장된 대사를 가져옴 
        int questTalkIndex = questManager.getQuestTalkIndex(id);
        string talkData = talkManager.getTalk(id + questTalkIndex, talkIndex);
        if(talkData =="") {

            isAction = false;
            talkIndex = 0;
            return;
        }
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
