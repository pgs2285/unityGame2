using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public Dictionary<int, QuestData> questList;

    public void Awake(){
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData(){
        questList.Add(10, new QuestData("이게 무슨일이고", new int[] {200,100}));
        questList.Add(20, new QuestData("나무가 없어졌다고?", new int[] { 200 }));
        questList.Add(30, new QuestData("나무가 다시돌아왔다고?", new int[] { 100 }));
    }
    public int getQuestTalkIndex(int id){
        return questId + questActionIndex;
    }
    public void checkQuest(int id){
        if (!questList.ContainsKey(questId)) return; //quest가 없으면 null
        if(id == questList[questId].npcId[questActionIndex]) questActionIndex++;


        if (questActionIndex == questList[questId].npcId.Length) NextQuest();

    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

}
