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
    }
    public int getQuestTalkIndex(int id){
        return questId + questActionIndex;
    }
    public void checkQuest(int id){
        if(id == questList[questId].npcId[questActionIndex])
        questActionIndex++;
    }
}
