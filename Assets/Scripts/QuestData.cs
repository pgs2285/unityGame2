using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    // Start is called before the first frame update
    public string questName;
    public int[] npcId; //퀘스트에 연관된 npc의 목록을 저장

    public QuestData(string name, int[] npc){ //생성자, 대입을 위해
        questName = name;
        npcId = npc;
    }

}
