using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjData : MonoBehaviour
{
    public int id;
    public bool isNPC;
    public GameObject mumbleChat;
    public TextMesh text;
    public string conversation;
    public void mumble() //3초마다 중얼거리게 만드는 함수
    {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            if (mumbleChat.activeSelf)
            {   
                mumbleChat.SetActive(false);
            }
            else
            {
                text.text = conversation;
                mumbleChat.SetActive(true);
            }
            timer = 0;
        }

    }
    float timer = 0;
    int waitingTime = 3;
    private void Update()
    {
            if(isNPC){
                mumble();
            }

       
    }
}
