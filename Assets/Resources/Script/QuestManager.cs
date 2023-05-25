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
    void Update(){
        QuestOngoing();
    }

    void GenerateData(){
        questList.Add(10, new QuestData("빛을 따라가보자", new int[] {2000}));
        questList.Add(20, new QuestData("배고픔", new int[] { 1000 }));
        questList.Add(30, new QuestData("배고픔", new int[] { 2000 }));
        questList.Add(40, new QuestData("배가 고파2", new int[]{2000}));
        questList.Add(50, new QuestData("나무열매를 찾아보자.", new int[] {3000} ));
        questList.Add(60, new QuestData("할말이 있어", new int[] { 2000 }));
        questList.Add(70, new QuestData(("너의 이름은?"), new int[] { 2000 }));
        ////////////cave///////////////////
        questList.Add(80, new QuestData(("동굴 탐험"), new int[] { 4000}));
        questList.Add(90, new QuestData(("동굴 탐험"), new int[] { 4000}));
        questList.Add(100, new QuestData(("동굴 탐험"), new int[] { 2000}));
        // questList.Add(100, new QuestData(("동굴 탐험"), new int[] { 5000}));

      

    }
    public int getQuestTalkIndex(int id){
        return CharacterData.Instance.QuestID + questActionIndex;
    }
    public void checkQuest(int id) {

        if (!questList.ContainsKey(CharacterData.Instance.QuestID)) return; //quest가 없으면 null

        if (id == questList[CharacterData.Instance.QuestID].npcId[questActionIndex]) questActionIndex++;

        
        NextQuest();
        QuestName.text = questList[CharacterData.Instance.QuestID].questName;
    }

    void NextQuest()
    {
        if (questActionIndex == questList[CharacterData.Instance.QuestID].npcId.Length) CharacterData.Instance.QuestID += 10;
        // else CharacterData.Instance.QuestID += 1;

        questActionIndex = 0;
    }
    enum NPCID{
        FOX = 1000,
    }
    void QuestOngoing(){
        Debug.Log(questList[CharacterData.Instance.QuestID].npcId[0]);
    }
}
