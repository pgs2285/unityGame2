using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public Dictionary<int,string[]> talkData;


    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    void GenerateData(){ //데이터 등록하기~
        
        talkData.Add(2000, new string[] { "뭘 봐?"});
        talkData.Add(1000, new string[] { "맑은 물이다." });
        talkData.Add(3000, new string[] { "나무이다." }); //열매달린 나무
        talkData.Add(4000, new string[] { "평범한 나무이다." }); // 일반나무
        talkData.Add(6000, new string[] { "벽에있는 이상한 무늬이다" });

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

        talkData.Add(2000 + 60, new string[] { "가져왔니?", "i키를 누르고 클릭하면 배고픔을 채울 수 있을거야", "배고픔은 매우 중요한 요소이니 잘 기억해둬!", "하지만... 가끔 음식들을 보면 요리해서 먹고 싶은생각이 들지않니?", "그럴땐 각 베이스 캠프에 있는 요리대가 있어!", "요리대를 이용하면 음식을 만들 수 있어!", "이번만 내가 도와줄게. 너에게 사과스프 레시피를 주었어!", "근처에서 사과 하나와 횃불 하나 주워서 나한테 말을 걸어봐~"});

        talkData.Add(2000 + 70, new string[]{"여기 보이는 나무가 이 모든 일의 근원지야.", "원래는 아름다운 동내였지만 어쩌다보니 이렇게 되었네..","(후드를 벗으며)", "너에게 남은 내 힘을 모두 전해줄게", "앞으로 이렇게만든 7대종을 물리치면서 이런 후드를 얻어가면 그 힘을 사용할 수 있을거야", "행운을 빌게", "옆에 포탈을 이용해서 먼저 곰을 잡으러 가봐."});
        talkData.Add(6000 + 80, new string[] { "벽에 이상한 무늬가 있다." , "수상한 빛이 내 몸에 스며들었다.","이 빛은 뭐지?", "뭔진 모르겠지만 앞으로의 동굴탐험에 큰 도움이 되겠어"});



    }
    public GameObject effect;
    public GameObject SKill1;
    public GameObject Tutorial;
    public Item TutorialFruit;
    public Item Touch;
    public TextMeshProUGUI TutorialMessage;

    

   
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
                        //Inventory.instance.AddItem(Touch, 2);
                        Destroy(GameObject.Find("TutorialApple"));

                        break;

                    case 2060:
                        if(!(Inventory.instance.itemList.Contains(TutorialFruit)) || !(Inventory.instance.itemList.Contains(Touch))){
                            CharacterData.Instance.QuestID = 60;  // 퀘스트아이디를 60으로 고정
                            GameObject.Find("QuestManager").GetComponent<QuestManager>().questActionIndex = 0;
                            return "";
                        }
                        break;

////////////////////////////////////여기부터 4 bearCave//////////////////////////////////////////
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
            
            if(!talkData.ContainsKey(id - (id % 10))){
                // 퀘스트 맨처음 대사가 없으면 (위 데이터기준 100,10의자리가 동시에 같은게 없을떄) 
                if (talkIndex == talkData[id - (id % 100)].Length) // ex) 100번 나무는 130대 퀘스트가 없으니 100 기본대사 출력한다는 뜻
                    return null;
                else
                    return talkData[id - (id % 100)][talkIndex];
            }
            else
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


    public GameObject fox;
    public GameObject cat;
    public GameObject lifeTreePortal;
    IEnumerator walkingToLifeTree()
    {
        Vector3 targetVector = fox.transform.position;
        targetVector.y += 60;
        while (Mathf.Abs(Vector3.Distance(targetVector, fox.transform.position)) > 0.001f)
        {
            fox.transform.position = Vector3.MoveTowards(fox.transform.position, targetVector, 0.03f);
            if(fox.transform.position.y < cat.transform.position.y)
            {
                Vector3 temp = cat.transform.position;
                temp.y -= 1;
                cat.transform.position = temp;
            }
            
            yield return new WaitForFixedUpdate();

        }
        yield return new WaitForFixedUpdate();
    }
}
