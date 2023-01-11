using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catNPC : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mumbleChat;
    public TextMesh text;

    public string conversation;
    public void mumble()
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
      
            mumble();

       
    }
}
