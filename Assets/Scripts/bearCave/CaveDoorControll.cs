using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveDoorControll : MonoBehaviour
{

    public GameObject blockingDoor1;
    void Update(){
        switch(CharacterData.Instance.questID){
            case 81:
                blockingDoor1.SetActive(false);
                //퀘스트 진행 여부에 따라 가로막는문이 사라진다.
            break;
        }
    }


}
