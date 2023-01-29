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
        talkData.Add(100, new string[] {"빛을 잃은 나무이다."});
        talkData.Add(200, new string[] {"이게 무슨일이고...", "...", "뭘 봐?"});
        /////////////////////////////////캐릭터들의 기본대사 (퀘스트와 관련이 없으면 출력)/////////////////////////////////////
        talkData.Add(200 + 10, new string[] {"저 나무는 원래 생기 있었던거 알았니?","어느 도둑들이 들어오고 빛을 잃었어","갑자기 수많은 재앙이 생기고 있어"});
        ////////////////////////// 1번퀘스트 종료 ////////////////////////////
        talkData.Add(100 + 20, new string[] { "나무는 빛을 잃었다.", "주변을 다시 둘러보자" });
        //////////////////////////2번퀘스트 종료//////////////////////////////
        talkData.Add(200 + 30, new string[] { "나무는 아직 여전하지?", "저번에 이 주변에 있던 몬스터들을 베어보니", "이상한 연기를 뿜으며 사라지더라고", "아무래도 나무와 관련이 있을듯 한데", "한번 확인해 주겠어?","한 10마리 정도만 죽이면 알아볼 수 있을거 같아." });
        //////////////////////// 3번 퀘스트 종료///////////////////////
        talkData.Add(0, new string[] { "123" });


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
