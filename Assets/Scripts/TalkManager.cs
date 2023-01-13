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
        talkData.Add(100, new string[] {"나무이다."});
        talkData.Add(200, new string[] {"이게 무슨일이고...", "...", "뭘 봐?"});
        /////////////////////////////////캐릭터들의 기본대사 (퀘스트와 관련이 없으면 출력)/////////////////////////////////////
        talkData.Add(200 + 10, new string[] {"이마을은 처음이니?","사실 나도그래","할거 없으면 나무 상태나 좀 살펴봐"});
        talkData.Add(100 + 11, new string[] {"생기를 잃은 나무이다."});
        ////////////////////////// 1번퀘스트 종료 ////////////////////////////
        talkData.Add(200 + 20, new string[] { "나무가 빛을 잃었다고??.", "근데 어쩌라고" });
        //////////////////////////2번퀘스트 종료//////////////////////////////
        talkData.Add(100 + 30, new string[] { "빛이 다시 돌아왔다" });
        talkData.Add(200 + 31, new string[] { "빛이 다시 돌아왔다고?", "good" });
        //////////////////////// 3번 퀘스트 종료///////////////////////
        talkData.Add(100 + 40, new string[] { "123" });
        talkData.Add(200 + 41, new string[] { "321" });
        talkData.Add(100 + 42, new string[] { "321" });
        talkData.Add(200 + 43, new string[] { "321" });


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
