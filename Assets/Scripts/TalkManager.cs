using System;
using System.Collections;
using System.Collections.Generic;
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
        talkData.Add(300, new string[] { "나무이다." });
        talkData.Add(400, new string[] { "평범한 나무이다." });
        /////////////////////////////////캐릭터들의 기본대사 (퀘스트와 관련이 없으면 출력)/////////////////////////////////////
        talkData.Add(200 + 10, new string[] {"??? : \n 이 동굴에 생명체는 오랜만이구나...", "??? : \n 그래, 여긴 어쩌다 오게 되었니?", "이브 : \n 나도 몰라", "이브 : \n 일어나 보니 여기였어."});
        talkData.Add(200 + 20, new string[] { "??? : \n 배가 고프나 보구나", " ??? : \n ...", "??? : \n 저기 옆에 웅덩이에서 물이라도 마셔보는게 어때?", "??? : \n 웅덩이는 오른쪽으로 쭉가면 있을꺼아." });
        ////////////////////////// 1번퀘스트 종료 ////////////////////////////
        talkData.Add(100 + 30, new string[] { "맑은 물이다.", "목을 축였다." });
        talkData.Add(200 + 40, new string[] { "??? : \n 어때 좀 괜찮아 졌어?", "??? : \n 아직 배가 고픈가 보구나.", "??? : \n 이 숲에는 먹을 수 있는 과일이 몇개 있어.", "??? : \n 주위에 나무들중에 하나쯤 있을거야.", "??? : \n 나무들을 보면서 확인해봐." });
        //////////////////////////2번퀘스트 종료//////////////////////////////
        talkData.Add(300 + 50, new string[] { "나무에 조그마한 열매가 보인다.", "한입 배어 물었더니 전보다 포만감이 느껴진다." });


    }
    public GameObject effect;
    public string getTalk(int id, int talkIndex){ //GenerateData에서 데이터 가져옴

        try
        {
            if (talkIndex == talkData[id - id % 10].Length)
            {
                switch (id) // 특정대사가 끝나고 컷신을 넣어주고 싶으면 여기서
                {

                    case 210:
                        effect.SetActive(true);
                        StartCoroutine(Effect(0));
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
}
