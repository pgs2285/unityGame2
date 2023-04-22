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
        for(int i =0; i<6;i++){
            HPBar.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = null;
        }
        for(int i = 0; i < CharacterData.Instance.MaxHP; i++){
            HPBar.transform.GetChild(i/2).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/EmptyHP");
        }
        for(int i =0; i < CharacterData.Instance.CurrentHP; i++){
            
            HPBar.transform.GetChild(i/2).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/FullHP");
            if(CharacterData.Instance.CurrentHP % 2 == 1){
                HPBar.transform.GetChild(CharacterData.Instance.CurrentHP/2).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/HalfHP");
            }
        //     if(CharacterData.Instance.Shield > 0){

        //     }
        }
        if(CharacterData.Instance.Shield > 0){
            for(int i = 0; i< CharacterData.Instance.Shield;i++){
                HPBar.transform.GetChild(CharacterData.Instance.MaxHP/2 + i/2).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/FullShield");
                if(CharacterData.Instance.Shield % 2 == 1){
                    HPBar.transform.GetChild(CharacterData.Instance.MaxHP/2 + CharacterData.Instance.Shield/2).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/HalfShield");
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

            if(endTalk){

                talk(objData.id, objData.isNPC);
                chatPanel.SetActive(isAction);
            }

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
            float delayTime = 0.03f;
            float lastUpdateTime = Time.time;
            for(int i = 0; i <= talkData.Length; i++){ //대사를 한글자씩 띄워줌
                coroutine =  StartCoroutine(ShowText(talkData, delayTime));
                endTalk = false;
            }
            StopCoroutine(coroutine);
            
        }
        talkIndex++;
        isAction = true;

    }
    Coroutine coroutine;
    bool endTalk = true;
    IEnumerator ShowText(string talkData, float delayTime)
    {
        for(int i = 0; i <= talkData.Length; i++){
            chatText.text = talkData.Substring(0, i);
            yield return new WaitForSeconds(delayTime);

        }
        endTalk = true;
    }
    

}
