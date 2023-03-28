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
        
        talkData.Add(200, new string[] { "뭘 봐?"});
        talkData.Add(100, new string[] { "맑은 물이다." });
        talkData.Add(300, new string[] { "나무이다." }); //열매달린 나무
        talkData.Add(400, new string[] { "평범한 나무이다." }); // 일반나무

        // 500 세계수
        //600 세계수 포탈(맵 전체이동 포탈)
        /////////////////////////////////캐릭터들의 기본대사 (퀘스트와 관련이 없으면 출력)/////////////////////////////////////
        talkData.Add(200 + 10, new string[] {"??? : \n 이 동굴에 생명체는 오랜만이구나...", "??? : \n 그래, 여긴 어쩌다 오게 되었니?", "이브 : \n 나도 몰라", "이브 : \n 일어나 보니 여기였어."});
        talkData.Add(200 + 20, new string[] { "??? : \n 배가 고프나 보구나", " ??? : \n ...", "??? : \n 저기 옆에 웅덩이에서 물이라도 마셔보는게 어때?", "??? : \n 웅덩이는 오른쪽으로 쭉가면 있을꺼아." });
        ////////////////////////// 1번퀘스트 종료 ////////////////////////////
        talkData.Add(100 + 30, new string[] { "맑은 물이다.", "목을 축였다." });
        talkData.Add(200 + 40, new string[] { "??? : \n 어때 좀 괜찮아 졌어?", "??? : \n 아직 배가 고픈가 보구나.", "??? : \n 이 숲에는 먹을 수 있는 과일이 몇개 있어.", "??? : \n 주위에 나무들중에 하나쯤 있을거야.", "??? : \n 나무들을 보면서 확인해봐." });
        //////////////////////////2번퀘스트 종료//////////////////////////////
        talkData.Add(300 + 50, new string[] { "나무에 조그만 열매가 보인다.", "사과를 획득했다." });

        talkData.Add(200 + 60, new string[] { "혼란스럽지?", " 아마 무슨일인가 싶을거야...", "일단 나를 따라와봐.", "지금까지 일어난 일에 대해 설명을 해줄게", "앞으로 쭉가다보면 덩굴이 하나 있을거야..", "내가 임시로 덩굴을 뛰어넘을 수 있는 방법을 하나 알려줄게", "이제부터 스페이스바를 누르면 일정 거리를 뛰어넘을 수 있을거야.", "덩굴 넘어서 보도록하자" });

        talkData.Add(200 + 70, new string[]{"여기 보이는 나무가 이 모든 일의 근원지야.", "원래는 아름다운 동내였지만 어쩌다보니 이렇게 되었네..","(후드를 벗으며)", "너에게 남은 내 힘을 모두 전해줄게", "앞으로 이렇게만든 7대종을 물리치면서 이런 후드를 얻어가면 그 힘을 사용할 수 있을거야", "행운을 빌게", "옆에 포탈을 이용해서 먼저 곰을 잡으러 가봐."});
        talkData.Add(600 + 80, new string[] { "벽에 이상한 무늬가 있다." , "수상한 빛이 내 몸에 스며들었다.","이 빛은 뭐지?", "뭔진 모르겠지만 앞으로의 동굴탐험에 큰 도움이 되겠어"});



    }
    public GameObject effect;
    public GameObject SKill1;
    public GameObject Tutorial;
    public Item TutorialFruit;
    public TextMeshProUGUI TutorialMessage;

   
    public string getTalk(int id, int talkIndex){ //GenerateData에서 데이터 가져옴

        try
        {
            if (talkIndex == talkData[id - id % 10].Length)
            {
                switch (id) // 특정대사가 끝나고 컷신 or 스킬을 넣어주고 싶으면 여기서
                {

                    case 210:
                        effect.SetActive(true);
                        StartCoroutine(Effect(0));
                        break;
                    case 260:
                        // CharacterData.Instance.IsDashAble = true;
                        TutorialMessage.text = "이제부터 Space를 누르면 일정거리를 텔레포트 할 수 있습니다";
                        Tutorial.SetActive(true);
                        StartCoroutine(Tutorial1Time());
                        SKill1.SetActive(true);

                        // ui활성화
                        StartCoroutine(walkingToLifeTree());
                        lifeTreePortal.SetActive(true);
                        /// 이후는 여우가 앞으로 걸어가되 주인공이 추월하지 못하는 식으로 y 55까지
                        break;

                    case 350:
                        Tutorial.SetActive(true);
                        StartCoroutine(Tutorial1Time());
                        Inventory.instance.AddItem(TutorialFruit, 1);
                        Destroy(GameObject.Find("TutorialApple"));

                        break;

                    case 270:
                    
                        

                        break;

////////////////////////////////////여기부터 4 bearCave//////////////////////////////////////////
                    case 680:
               
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
            Debug.Log("No data");
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
