using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public Dictionary<int,string[]> talkData;
    

    void GenerateData(){ //데이터 등록하기~
        
        talkData.Add(2000, new string[] { "??? : 뭘 봐?"});
        talkData.Add(1000, new string[] { "나무이다." });

        talkData.Add(4000, new string[] { "안녕~" }); // 일반나무
        
        

        // 500 세계수
        //600 세계수 포탈(맵 전체이동 포탈)
        /////////////////////////////////캐릭터들의 기본대사 (퀘스트와 관련이 없으면 출력)/////////////////////////////////////
        talkData.Add(2000 + 10, new string[] {"??? : 어이 이봐!.","??? : 배가 많이 고파보이는군", "??? :  <color=red>오른쪽에 있는 통나무를 타고 넘어가면 사과가 달린 나무</color>가 있어. 배고프다면 사과를 먹어도 좋아", "??? : 날라오는 바위는 알아서 잘 피해봐."});
        talkData.Add(1000 + 20, new string[] { "사과이다." });
        ////////////////////////// 1번퀘스트 종료 ////////////////////////////
        talkData.Add(2000 + 30, new string[]{"??? : 사과 가져왔어?", "??? : 먹고싶다면 I를 눌러서 먹도록 해.", "??? : 왼쪽 상단의 포만감이 늘어날거야."});
        talkData.Add(2000 + 40, new string[] { "??? : 포만감이 0이되면 게임 오버 되니 조심하도록 해","??? :  단일 재료만으론 배를 채우기 쉽지 않지.", "??? : 내가 사과스프 레시피를 하나 알려줄게.", "??? : 옆에 가마솥에 해당 레시피 요구재료를 넣어서  사과스프를 만들어봐.","??? : 주변을 둘러보면 재료를 찾을 수 있을거야." });

        //////////////////////////2번퀘스트 종료//////////////////////////////

        talkData.Add(2000 + 50, new string[] { "??? : 포만감이 어느정도 채워진거 같네.","??? : 울타리가 가로막고있어 나아갈수가 없어.", "??? : 공격키를 눌러 한번 부숴봐. "});

        talkData.Add(2000+60, new string[]{"??? : 좋아. 그렇게 하는거야.", "??? : 따라와봐!"});
        talkData.Add(2000+70 , new string[]{"??? :입구는 여기야"});


    }
    public GameObject effect;
    
    public GameObject Tutorial;
    Item TutorialFruit;
    
    public TextMeshProUGUI TutorialMessage;
    public GameObject[] spaceClick;

    public GameObject mouseClickTutorial;
    
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
        TutorialFruit = Resources.Load<Item>("Item/TutorialFruit");
        fox = GameObject.Find("FOX");
        cat = GameObject.FindWithTag("Player");
    }
    int[] count = {0,0,0,0,0,0,0,0,0};
    public GameObject spaceClick_Tree;
    QuestManager questManager;
    public string getTalk(int id, int talkIndex){ //GenerateData에서 데이터 가져옴

        questManager = GameObject.Find("QuestManager").GetComponent<QuestManager>();
        try
        {
            if (talkIndex == talkData[id - id % 10].Length)
            {
                switch (id) // 특정대사가 끝나고 컷신 or 스킬을 넣어주고 싶으면 여기서
                {
                    
                    case 2010:
                        effect.SetActive(true);
                        StartCoroutine(Effect(0));
                        spaceClick_Tree.SetActive(true);
                        Destroy(questManager.questState);
                        questManager.questState = Instantiate(Resources.Load("QuestState/questOngoing_0") as GameObject, new Vector2(fox.transform.position.x + 0.5f, fox.transform.position.y +0.8f), Quaternion.identity);
                        

                        break;

                    case 1020:
                        Tutorial.SetActive(true);
                        TutorialMessage.text = "I키를 누르면 아이템을 볼 수 있습니다.  \n주변 지형지물들과 상호작용 하면 숨겨진 음식을 얻을 수 있습니다. \n음식이 없더라도 절망하지 마세요! 음식은 가끔 자라기도한답니다.";
                        StartCoroutine(Tutorial1Time());
                        Inventory.instance.AddItem(TutorialFruit, 1);
                        Destroy(GameObject.Find("TutorialApple"));
                        Destroy(questManager.questState);
                        questManager.questState = Instantiate(Resources.Load("QuestState/QuestStartOrEnd") as GameObject, new Vector2(fox.transform.position.x + 0.5f, fox.transform.position.y +0.8f), Quaternion.identity);

                        break;
                    case 2030:
                        if((Inventory.instance.itemList.Contains(TutorialFruit))){
                            CharacterData.Instance.QuestID = 30;  // 퀘스트아이디를 30으로 고정
                            GameObject.Find("QuestManager").GetComponent<QuestManager>().questActionIndex = 0;
                            Destroy(questManager.questState);
                            questManager.questState = Instantiate(Resources.Load("QuestState/questOngoing_0") as GameObject, new Vector2(fox.transform.position.x + 0.5f, fox.transform.position.y +0.8f), Quaternion.identity);
                            return "";
                        }
                        break;

                    case 2040:
                        if(count[1] == 0){ // 한번만 실행되야하는요소.
                            Destroy(questManager.questState);
                            StartCoroutine(walkingToLifeTree("y", 3, 2040)); //y로 3만큼 이동.
                            
                            count[1]++;
                        }if((!Inventory.instance.itemList.Contains(Resources.Load<Item>("Item/AppleSoup")))){ // 만약 사과스프가 없으면 (만들지 않았다면.)
                            CharacterData.Instance.QuestID = 40;  // 퀘스트아이디를 40으로 고정
                            GameObject.Find("QuestManager").GetComponent<QuestManager>().questActionIndex = 0;
                            foreach(GameObject obj in spaceClick){
                                obj.SetActive(true);
                                Destroy(obj, 10f);
                            }
                            return "";
                        }

                
                        break;

                    case 2050:
                        if(count[0] == 0){
                            Destroy(questManager.questState);
                            StartCoroutine(walkingToLifeTree("y", 3)); //y로 3만큼 이동.
                            count[0]++;
                        }
                        CharacterData.Instance.QuestID = 50;  // 퀘스트아이디를 80으로 고정
                        GameObject.Find("QuestManager").GetComponent<QuestManager>().questActionIndex = 0;
                        mouseClickTutorial.SetActive(true);

                        return "";

                        break;
////////////////////////////////////여기부터 4 bearCave//////////////////////////////////////////
                    case 2060:
                        // 1.5,8 -> 9,8 -> 9,10,  -> 16,10 (x,y 좌표값)
                        Destroy(questManager.questState);
                        StartCoroutine(walkingToLifeTree("x", 7.5f, 2060)); //x로 9만큼 이동.
                        break;

                    case 4080:

                        if(!Inventory.instance.itemList.Contains(Resources.Load<Item>("Item/goldRecipe"))){
                            CharacterData.Instance.QuestID = 80;  // 퀘스트아이디를 80으로 고정
                            GameObject.Find("QuestManager").GetComponent<QuestManager>().questActionIndex = 0;
                            return "";
                        }
                        break;
                    case 4090: 
                        Inventory.instance.AddItem(Resources.Load<Item>("Item/beautifulStone"), 1);
                        Inventory.instance.RemoveItem(Resources.Load<Item>("Item/goldRecipe"), 1);
                    break;

    
                }
            }
        } catch (Exception e)
        {
            Debug.LogException(e);
        }
 
        if (!talkData.ContainsKey(id))
        {
            if(talkData.ContainsKey(id - (id % 1000))){
                if (talkIndex == talkData[id - id % 1000].Length) // 대사가 종료되었다면
                {
                    return null;
                }
                else
                {
                    return talkData[id - id % 1000][talkIndex];
                }
            }
            else if(talkData.ContainsKey(id - (id % 100))){
                // 퀘스트 맨처음 대사가 없으면 (위 데이터기준 100,10의자리가 동시에 같은게 없을떄) 
                if (talkIndex == talkData[id - (id % 100)].Length) // ex) 100번 나무는 130대 퀘스트가 없으니 100 기본대사 출력한다는 뜻
                    return null;
                else
                    return talkData[id - (id % 100)][talkIndex];
            }
            else if(talkData.ContainsKey(id - (id % 10)))
            {
                if (talkIndex == talkData[id - id % 10].Length) // 대사가 종료되었다면
                {
                    return null;
                }
                else
                {
                    return talkData[id - id % 10][talkIndex];
                }
            }
            else
                Debug.Log("대사가 없는 id입니다. id : " + id + " talkIndex : " + talkIndex + " talkData : " + talkData.ContainsKey(id));
            
        }
        if(talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    IEnumerator Effect(int nun)
    {
        yield return new WaitForSeconds(2.0f);
        effect.SetActive(false);
    }
    IEnumerator Tutorial1Time()
    {
        yield return new WaitForSeconds(5.0f);
        Tutorial.SetActive(false);
    }


    GameObject fox;
    GameObject cat;
    IEnumerator walkingToLifeTree(string xory,float increase, int id = 0)
    {
        Vector3 targetVector = fox.transform.position;
        fox.GetComponent<Animator>().SetBool("move", true);
        if(xory == "x") targetVector.x += increase;
        else if(xory=="y") targetVector.y += increase;

        while (Mathf.Abs(Vector3.Distance(targetVector, fox.transform.position)) > 0.001f)
        {
            fox.transform.position = Vector3.MoveTowards(fox.transform.position, targetVector, 0.05f);
            // if(fox.transform.position.y < cat.transform.position.y)
            // {
            //     Vector3 temp = cat.transform.position;
            //     temp.y -= 1;
            //     cat.transform.position = temp;
            // }
            
            yield return new WaitForFixedUpdate();

        }
        yield return new WaitForFixedUpdate();
        fox.GetComponent<Animator>().SetBool("move", false);
        if(id == 2040){
            Vector3 pos = GameObject.Find("FOX").transform.position;
            pos.x+=2;
            Instantiate(Resources.Load<GameObject>("Prefab/Pot"), pos, Quaternion.identity);
            questManager.questState = Instantiate(Resources.Load("QuestState/questOngoing_0") as GameObject, new Vector2(fox.transform.position.x + 0.5f, fox.transform.position.y +0.8f), Quaternion.identity);
        }
        else if(id == 2050){
            questManager.questState = Instantiate(Resources.Load("QuestState/questOngoing_0") as GameObject, new Vector2(fox.transform.position.x + 0.5f, fox.transform.position.y +0.8f), Quaternion.identity);
        }
        else if(id == 2060) { // 9,8 -> 9,10,  -> 16,10 
            if(step == 0){
            step = 1;
            StartCoroutine(walkingToLifeTree("y", 2, 2060));
            
            }else if(step == 1){
                step = 2;
                StartCoroutine(walkingToLifeTree("x", 7, 2060));
                
            }else if(step == 2){
                step = 3;
                StartCoroutine(walkingToLifeTree("y", 2));

                
            }else if(step == 3){
                questManager.questState = Instantiate(Resources.Load("QuestState/QuestStartOrEnd") as GameObject, new Vector2(fox.transform.position.x + 0.5f, fox.transform.position.y +0.8f), Quaternion.identity);
            }
        }

    }
    int step = 0;

}
