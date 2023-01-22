using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public Dictionary<int, QuestData> questList;
    
    public void Awake(){

        questList = new Dictionary<int, QuestData>();
        GenerateData();
        QuestName.text = questList[CharacterData.Instance.QuestID].questName;
    }
    public TextMeshProUGUI QuestName;

    void GenerateData(){
        questList.Add(10, new QuestData("마을 둘러보기", new int[] {200,100}));
        questList.Add(20, new QuestData("나무가 없어졌다고?", new int[] { 200 }));
        questList.Add(30, new QuestData("나무가 다시돌아왔다고?", new int[] { 100, 200 }));
        questList.Add(40, new QuestData("엔딩", new int[] { 100, 200, 100, 200 }));
    }
    public int getQuestTalkIndex(int id){
        return CharacterData.Instance.QuestID + questActionIndex;
    }
    public void checkQuest(int id){
        if (!questList.ContainsKey(CharacterData.Instance.QuestID)) return; //quest가 없으면 null
        if(id == questList[CharacterData.Instance.QuestID].npcId[questActionIndex]) questActionIndex++;


        if (questActionIndex == questList[CharacterData.Instance.QuestID].npcId.Length) NextQuest();
        QuestName.text = questList[CharacterData.Instance.QuestID].questName;
    }

    void NextQuest()
    {
        CharacterData.Instance.QuestID += 10;
        questActionIndex = 0;
    }

}
