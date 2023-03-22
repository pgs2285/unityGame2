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
        questList.Add(10, new QuestData("빛을 따라가보자", new int[] {200}));
        questList.Add(20, new QuestData("의문의 존재", new int[] { 200 }));
        questList.Add(30, new QuestData("배가 고파1", new int[] { 100 }));
        questList.Add(40, new QuestData("배가 고파2", new int[]{200}));
        questList.Add(50, new QuestData("나무열매를 찾아보자.", new int[] {300} ));
        questList.Add(60, new QuestData("할말이 있어", new int[] { 200 }));
      

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
        /*        if (questList[CharacterData.Instance.QuestID].npcId[0] == 0)
                {

                    Debug.Log("몬스터 처치용 퀘스트 입니다.");
                    Debug.Log(CharacterData.Instance.QuestID); // 여기에 몹 잡는거 카운트해주는 함수 호출해서 일정이상 잡으면 넘어감 될듯?
                }
          */


        questActionIndex = 0;
    }

}
