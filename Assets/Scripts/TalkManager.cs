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
        /////////////////////////////////캐릭터들의 기본대사 (퀘스트와 관련이 없으면 출력)/////////////////////////////////////
        talkData.Add(200 + 10, new string[] {"이 동굴에 생명체는 오랜만이구나...", "..."});
        ////////////////////////// 1번퀘스트 종료 ////////////////////////////
        talkData.Add(100 + 20, new string[] { "나무는 빛을 잃었다.", "주변을 다시 둘러보자" });
        //////////////////////////2번퀘스트 종료//////////////////////////////
 


    }

    public string getTalk(int id, int talkIndex){ //GenerateData에서 데이터 가져옴

        if (!talkData.ContainsKey(id))
        {
            if(!talkData.ContainsKey(id - id % 10)){
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
}
