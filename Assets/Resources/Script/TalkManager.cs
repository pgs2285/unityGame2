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

        talkData.Add(4000, new string[] { "평범한 나무이다." }); // 일반나무
        talkData.Add(6000, new string[] { "막혀있다. 열 방법을 찾아봐야겠다." });
        

        // 500 세계수
        //600 세계수 포탈(맵 전체이동 포탈)
        /////////////////////////////////캐릭터들의 기본대사 (퀘스트와 관련이 없으면 출력)/////////////////////////////////////
        talkData.Add(2000 + 10, new string[] {"??? : 드디어 왔구나.", "??? : 많이 기다렸어.", "??? : 배가 고픈가보구나?", "??? : 오른쪽으로 가면 길이있어. 오른쪽에 가면 사과가 있을거야", "??? : 누군가가 다리 건너편에 방해요소를 두었어. 조심히 건너도록해."});
        talkData.Add(1000 + 20, new string[] { "나무에 잘익은 열매가 하나 보인다." });
        ////////////////////////// 1번퀘스트 종료 ////////////////////////////
        talkData.Add(2000 + 30, new string[]{"??? : 사과를 가져왔니?", "??? : 사과를 한번 먹어봐.", "배고픔이 어느정도 완화될거야."});
        talkData.Add(2000 + 40, new string[] { "??? : 배고픔이 0이되면 게임 오버 되니 조심하도록해","??? : 여전히 베가 고파보이네. 역시 단일 음식으로는 배를 채우기 쉽지 않지.", "??? : 내가 사과스프 레시피를 하나 알려줄게.", "??? : 옆에 가마솥에 해당 레시피 요구재료를 넣어서 하나 사과스프 하나 만들어와봐.","??? :사과스프 레시피는 주변을 둘러보면 찾을 수 있을거야" });
        
        //////////////////////////2번퀘스트 종료//////////////////////////////

        talkData.Add(2000 + 50, new string[] { "??? : 앞에 울타리가 가로막고있어 나아갈수가 없네.", "??? : 공격키를 눌러 한번 부숴봐. 너라면 할수있어"});

        talkData.Add(2000+60, new string[]{"??? : 좋아. 지금 감각 잘 익혀두면 앞으로 편할거야.", "??? : 이제 계속 나를 따라와봐."});
        talkData.Add(2000,70 , new string[]{"??? : 들어가"});
        
        talkData.Add(2000 + 80 , new string[]{"재료를 모아왔구나.", "이제 옆에 음식대를 설치해줄게" , "레시피는 일단 내가 하나 알려줄게! 나머지 레시피는 앞으로 나아가다보면 얻을 수 있을거야.","재료는 그때그때 수급하며 음식을 만들어봐!", "이제 한번 사과스프를 만들어보렴"});
        talkData.Add(2000 + 90, new string[] {"음식을 만들었구나.", "이제 한번 먹어보렴", "아까보다 맛도 좋고 포만감도 많이 오를거야.", "이제 기본적인것 설명은 끝난거 같고 한번 나를 따라와봐"});
        talkData.Add(2000+100, new string[]{"여기 울타리로 막혀있어서 더 지나갈 수가 없네...", "앞에있는 울타리 보이니?","앞으로의 편한 통행을 위해 모두 부시고 다시한번 말을걸어줘."});
        
  


    }
    public GameObject effect;
    
    public GameObject Tutorial;
    Item TutorialFruit;
    
    public TextMeshProUGUI TutorialMessage;


    
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
        TutorialFruit = Resources.Load<Item>("Item/TutorialFruit");
        fox = GameObject.Find("FOX");
        cat = GameObject.FindWithTag("Player");
        
        lifeTreePortal = GameObject.Find("movePortal");
    }
    int[] count = {0,0,0,0,0,0,0,0,0};
   
    public string getTalk(int id, int talkIndex){ //GenerateData에서 데이터 가져옴

        try
        {
            if (talkIndex == talkData[id - id % 10].Length)
            {
                switch (id) // 특정대사가 끝나고 컷신 or 스킬을 넣어주고 싶으면 여기서
                {

                    case 2010:
                        effect.SetActive(true);
                        StartCoroutine(Effect(0));
                        break;

                    case 1020:
                        Tutorial.SetActive(true);
                        StartCoroutine(Tutorial1Time());
                        Inventory.instance.AddItem(TutorialFruit, 1);
                        Destroy(GameObject.Find("TutorialApple"));

                        break;
                    case 2030:
                        if((Inventory.instance.itemList.Contains(TutorialFruit))){
                            CharacterData.Instance.QuestID = 30;  // 퀘스트아이디를 30으로 고정
                            GameObject.Find("QuestManager").GetComponent<QuestManager>().questActionIndex = 0;
                            return "";
                        }
                        break;

                    case 2040:
                        if(count[1] == 0){ // 한번만 실행되야하는요소.
                            StartCoroutine(walkingToLifeTree("y", 3, 2040)); //y로 3만큼 이동.
                            count[1]++;
                        }if((!Inventory.instance.itemList.Contains(Resources.Load<Item>("Item/AppleSoup")))){ // 만약 사과스프가 없으면 (만들지 않았다면.)
                            CharacterData.Instance.QuestID = 40;  // 퀘스트아이디를 40으로 고정
                            GameObject.Find("QuestManager").GetComponent<QuestManager>().questActionIndex = 0;
                            return "";
                        }

                
                        break;

                    case 2050:
                        if(count[0] == 0){
                            StartCoroutine(walkingToLifeTree("y", 3)); //y로 3만큼 이동.
                            count[0]++;
                        }
                        CharacterData.Instance.QuestID = 50;  // 퀘스트아이디를 80으로 고정
                        GameObject.Find("QuestManager").GetComponent<QuestManager>().questActionIndex = 0;
                        return "";

                        break;
////////////////////////////////////여기부터 4 bearCave//////////////////////////////////////////
                    case 2060:
                        // 1.5,8 -> 9,8 -> 9,10,  -> 16,10 (x,y 좌표값)
                        StartCoroutine(walkingToLifeTree("x", 7.5f, 2060)); //x로 9만큼 이동.
                        break;

                    case 2080:

                        if(!Inventory.instance.itemList.Contains(Resources.Load<Item>("Item/AppleSoup"))){
                            CharacterData.Instance.QuestID = 80;  // 퀘스트아이디를 80으로 고정
                            GameObject.Find("QuestManager").GetComponent<QuestManager>().questActionIndex = 0;
                            return "";
                        }
                        break;
                    case 2090: //여우를 따라가서 울타리를 부수기. 대충 y = 5로 이동시키면 될듯.
                        StartCoroutine(walkingToLifeTree("y", 24)); //y로 10만큼 이동.
                    break;
                    case 2100:
                            CharacterData.Instance.QuestID = 100;  // 퀘스트아이디를 80으로 고정
                            GameObject.Find("QuestManager").GetComponent<QuestManager>().questActionIndex = 0;
                            return "";
                    case 2110:
                        StartCoroutine(walkingToLifeTree("y", 27)); 
                        break;
                    case 2120:
                        Tutorial.SetActive(true);
                        TutorialMessage.text = "Q를 누르면 다른 동물로 변신 할 수 있습니다. 후드는 진행하며 얻어가세요. 또한 Tab을 누르면 각 후드를 강화할 수 있습니다.";
                        StartCoroutine(Tutorial1Time());
                        lifeTreePortal.SetActive(true);
                        break;
                    case 6080:
                        
                        break;
                    default:
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
    public GameObject lifeTreePortal;
    IEnumerator walkingToLifeTree(string xory,float increase, int id = 0)
    {
        Vector3 targetVector = fox.transform.position;
        fox.GetComponent<Animator>().SetBool("move", true);
        if(xory == "x") targetVector.x += increase;
        else if(xory=="y") targetVector.y += increase;

        while (Mathf.Abs(Vector3.Distance(targetVector, fox.transform.position)) > 0.001f)
        {
            fox.transform.position = Vector3.MoveTowards(fox.transform.position, targetVector, 0.05f);
            if(fox.transform.position.y < cat.transform.position.y)
            {
                Vector3 temp = cat.transform.position;
                temp.y -= 1;
                cat.transform.position = temp;
            }
            
            yield return new WaitForFixedUpdate();

        }
        yield return new WaitForFixedUpdate();
        fox.GetComponent<Animator>().SetBool("move", false);
        if(id == 2040){
            Vector3 pos = GameObject.Find("FOX").transform.position;
            pos.x+=2;
            Instantiate(Resources.Load<GameObject>("Prefab/Pot"), pos, Quaternion.identity);
        }
        else if(id == 2060) { // 9,8 -> 9,10,  -> 16,10 
            if(step == 0){
            step = 1;
            StartCoroutine(walkingToLifeTree("y", 2, 2060));
            
            }else if(step == 1){
                step = 2;
                StartCoroutine(walkingToLifeTree("x", 7, 2060));
                
            }else if(step == 2){
                StartCoroutine(walkingToLifeTree("y", 2, 2060));
            }
        }
    }
    int step = 0;

}
