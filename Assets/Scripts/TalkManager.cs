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
        talkData.Add(100 + 10, new string[] {"나무이다."});
        talkData.Add(200, new string[] {"이게 무슨일이고...", "...", "뭘 봐?"});
        talkData.Add(200 + 10, new string[] {"이마을은 처음이니?","사실 나도그래","할거 없으면 나무 상태나 좀 살펴봐"});
        talkData.Add(100 + 11, new string[] {"생기를 잃은 나무이다."});
    }

    public string getTalk(int id, int talkIndex){ //GenerateData에서 데이터 가져옴
        if(talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
