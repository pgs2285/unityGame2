using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public Dictionary<int,string[]> talkData;


    void GenerateData(){ //데이터 등록하기~
        
        talkData.Add(2000, new string[] { "뭘 봐?"});
        talkData.Add(1000, new string[] { "맑은 물이다." });
        talkData.Add(3000, new string[] { "나무이다." }); //열매달린 나무
        talkData.Add(4000, new string[] { "평범한 나무이다." }); // 일반나무
        talkData.Add(6000, new string[] { "막혀있다. 열 방법을 찾아봐야겠다." });
        

        // 500 세계수
        //600 세계수 포탈(맵 전체이동 포탈)
        /////////////////////////////////캐릭터들의 기본대사 (퀘스트와 관련이 없으면 출력)/////////////////////////////////////
        talkData.Add(2000 + 10, new string[] {"??? : \n 이 동굴에 생명체는 오랜만이구나...", "??? : \n 그래, 여긴 어쩌다 오게 되었니?", "이브 : \n 나도 몰라", "이브 : \n 일어나 보니 여기였어."});
        talkData.Add(2000 + 20, new string[] { "??? : \n 배가 고프나 보구나", " ??? : \n ...", "??? : \n 저기 옆에 웅덩이에서 물이라도 마셔보는게 어때?", "??? : \n 웅덩이는 오른쪽으로 쭉가면 있을꺼아." });
        ////////////////////////// 1번퀘스트 종료 ////////////////////////////
        talkData.Add(1000 + 30, new string[] { "맑은 물이다.", "목을 축였다." });
        talkData.Add(2000 + 40, new string[] { "??? : \n 어때 좀 괜찮아 졌어?", "??? : \n 아직 배가 고픈가 보구나.", "??? : \n 위에 숲에는 먹을 수 있는 과일이 있을거야.", "??? : \n 주위에 나무들중에 하나쯤 있을거야.", "??? : \n 나무들을 보면서 확인해봐." });
        //////////////////////////2번퀘스트 종료//////////////////////////////
        talkData.Add(3000 + 50, new string[] { "나무에 조그만 열매가 보인다.", "사과를 획득했다." });

        talkData.Add(2000 + 60, new string[] { "가져왔니?", "i키를 누르고 클릭하면 배고픔을 채울 수 있을거야", "배고픔은 매우 중요한 요소이니 잘 기억해둬!","사과를 먹고 다시한번 말을 걸어봐~"});

        talkData.Add(2000+70, new string[]{"사과를 먹었구나.", "포만감이 많이 오른거 같네", "하지만 아직도 배가 고파보여...", "그런 단일 아이템으로는 배고픔을 채울 수 없어.", "그래서 여러가지 재료를 모아서 요리를 해야해."," 내가 남은 사과를 하나 줄게 절대 먹지말고... 먹으면 게임망해", "한번 토치를 찾아서 요리를해보자!", "토치는 오른쪽 섬 어딘가에 있을거야!"});
      
        talkData.Add(2000 + 80 , new string[]{"재료를 모아왔구나.", "이제 옆에 음식대를 설치해줄게" , "레시피는 일단 내가 하나 알려줄게! 나머지 레시피는 앞으로 나아가다보면 얻을 수 있을거야.","재료는 그때그때 수급하며 음식을 만들어봐!", "이제 한번 사과스프를 만들어보렴"});
        talkData.Add(2000 + 90, new string[] {"음식을 만들었구나.", "이제 한번 먹어보렴", "아까보다 맛도 좋고 포만감도 많이 오를거야.", "이제 기본적인것 설명은 끝난거 같고 한번 나를 따라와봐"});
        talkData.Add(2000+100, new string[]{"여기 울타리로 막혀있어서 더 지나갈 수가 없네...", "앞에있는 울타리 보이니?","앞으로의 편한 통행을 위해 모두 부시고 다시한번 말을걸어줘."});
        talkData.Add(2000 + 110 , new string[]{"이제 울타리를 부숴서 지나갈 수 있게 되었어.", "이제 다시한번 나를 따라와봐"});
        talkData.Add(2000+120, new string[]{"여기가 이 모든일의 근원이야","너는 기억이 없겠지만 이 정말 많은 일이 있었어","7마리의 동물들은 세계수에 열린 열매를 먹고 믿을 수 없는 힘을 얻었지만, 그 힘을 과시하는 방법이 잘못됐어.","너는 그것을 지키는 과정에서 기억을 잃었을거야","이제 내가 너에게 후드를 하나줄게","이것을 입고 싸우면 지금과는 다른 힘을 얻을 수 있을거야"});
  


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

                    case 3050:
                        Tutorial.SetActive(true);
                        StartCoroutine(Tutorial1Time());
                        Inventory.instance.AddItem(TutorialFruit, 1);
                        Destroy(GameObject.Find("TutorialApple"));

                        break;

                    case 2060:
                        if((Inventory.instance.itemList.Contains(TutorialFruit))){
                            CharacterData.Instance.QuestID = 60;  // 퀘스트아이디를 60으로 고정
                            GameObject.Find("QuestManager").GetComponent<QuestManager>().questActionIndex = 0;
                            return "";
                        }
                        break;

                    case 2070:
                        if(count[0] == 0) {
                            Inventory.instance.AddItem(Resources.Load<Item>("Item/Apple"), 1); // 레시피용 사과 하나 주기
                            count[0]++;
                        }
                        
                        if(!Inventory.instance.itemList.Contains(Resources.Load<Item>("Item/Torch"))){
                            CharacterData.Instance.QuestID = 70;  // 퀘스트아이디를 70으로 고정
                            GameObject.Find("QuestManager").GetComponent<QuestManager>().questActionIndex = 0;
                            return "";
                        }
                        break;
////////////////////////////////////여기부터 4 bearCave//////////////////////////////////////////

                    case 2080:
                    if(count[1] == 0){
                        Vector3 pos = GameObject.Find("FOX").transform.position;
                        pos.x+=2;
                        Instantiate(Resources.Load<GameObject>("Prefab/Pot"), pos, Quaternion.identity);
                        count[1]++;
                    }
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
        Debug.Log("여기");
        if (!talkData.ContainsKey(id))
        {
            
            if(!talkData.ContainsKey(id - (id % 10))){
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
    IEnumerator walkingToLifeTree(string xory,float increase)
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
    }


}
