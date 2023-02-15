using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct moveInfo{
    public bool isMove;
    
    public GameObject npcID;
    public string direction;
    public float figure; 
    public float speed;
    public float Delay;
    public string[] context;
}

public class secondCutScene : MonoBehaviour
{
    [SerializeField]
    public moveInfo[] mvInfo;


    private void Start(){
        
        if(mvInfo[0].isMove) StartCoroutine(move(0));
        
    }

    Vector3 targetVector;
    IEnumerator move(int index){
        yield return new WaitForSeconds(mvInfo[index].Delay);
        Debug.Log(mvInfo[index].direction);
        switch(mvInfo[index].direction){
            case "UP":
            targetVector = mvInfo[index].npcID.transform.position;
            targetVector.y += mvInfo[index].figure;
            break;

            case "DOWN":
            targetVector = mvInfo[index].npcID.transform.position;
            targetVector.y -= mvInfo[index].figure;
            break;
            
            case "LEFT":
            targetVector = mvInfo[index].npcID.transform.position;
            targetVector.x -= mvInfo[index].figure;
            break;

            case "RIGHT":
            targetVector = mvInfo[index].npcID.transform.position;
            targetVector.x += mvInfo[index].figure;
            break;
        }

        while(Mathf.Abs(Vector3.Distance(targetVector, mvInfo[index].npcID.transform.position)) > 0.001f){ // 근접시
            Debug.Log(Vector3.Distance(targetVector, mvInfo[index].npcID.transform.position));
            mvInfo[index].npcID.transform.position = Vector3.MoveTowards(mvInfo[index].npcID.transform.position, targetVector, mvInfo[index].speed);
            yield return new WaitForSeconds(0.00001f); // return을 통해 Scene에 진행과정 보이게함
        
        }

        index += 1;
        if(index < mvInfo.Length)
        {
            if(mvInfo[index].isMove) StartCoroutine(move(index));
        } 
    }
    
}
