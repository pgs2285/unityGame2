using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{   
    [SerializeField]
    private GameObject hpBar;

    GameObject player;

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
        player = GameObject.FindWithTag("Player");
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

    public bool isInteration = false; 
    public void Action(GameObject scanObj){ //대사 띄워줌

            scanObject = scanObj;
            // Debug.Log("UIMANAGER+SCANOBJECT" + scanObject.name);
            ObjData objData = scanObject.GetComponent<ObjData>();

            if(endTalk && !isInteration){
                talk(objData.id, objData.isNPC);
                // chatPanel.SetActive(isAction);
                GameObject.Find("ChatWindow").GetComponent<Animator>().SetBool("isShow",isAction);
            }

    }

    TalkManager talkManager;
    QuestManager questManager;
    float delayTime = 0.03f;  
    string fullText;
    string[] talkData;
    public GameObject namePanel;
    public void talk(int id, bool isNPC){ //talkManager에 있을 캐릭터의 저장된 대사를 가져옴 
        int questTalkIndex = questManager.getQuestTalkIndex(id);
        string fullText = talkManager.getTalk(id + questTalkIndex, talkIndex);
            if(fullText =="") {

                isAction = false;
                talkIndex = 0;
                return;
            }
            if(fullText == null){
                isAction = false;
                talkIndex = 0;
                questManager.checkQuest(id);
                return;
            }
        talkData = fullText.Split(':');
        if(talkData.Length <= 1){
            namePanel.SetActive(false);
            
            coroutine =  StartCoroutine(ShowText(talkData[0], delayTime));
            endTalk = false;
        }else if(talkData.Length == 2){
            namePanel.SetActive(true);
            nameText.text = talkData[0];


            coroutine =  StartCoroutine(ShowText(talkData[1], delayTime));
            endTalk = false;
        }
        // StopCoroutine(coroutine);
        
        talkIndex++;
        isAction = true;

    }
    public TextMeshProUGUI nameText;
    Coroutine coroutine;
    bool endTalk = true;
    IEnumerator ShowText(string talkData, float delayTime)
    {
        for(int i = 0; i <= talkData.Length; i++){
            try{       
                if(talkData[i].Equals('<')){
                    if(talkData.Substring(i, 7).Equals("<color>")){
                        i += 7;
                        while(!talkData[i].Equals('>')){
                            i++;
                        }
                        i++; // 해당 태그의 길이만큼 건너뛰기
                    }
                    else{
                        while(!talkData[i].Equals('>')){
                            i++;
                        }
                        i++; // 해당 태그의 길이만큼 건너뛰기
                    }
                }
        }catch{
            Debug.Log("대화 끝");
        }
        chatText.text = talkData.Substring(0, i);
        yield return new WaitForSeconds(delayTime);
    }
        endTalk = true;
    }

    void ItemPanelEnd(){
        GameObject.Find("ItemPanel").GetComponent<Animator>().SetBool("state",false);
    }
    

}
