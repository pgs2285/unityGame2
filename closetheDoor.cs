using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class closetheDoor : MonoBehaviour
{


    public Animator LeftdoorAnimation;
    public Animator RightdoorAnimation;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Player") {

            LeftdoorAnimation.SetBool("Open",true);
            RightdoorAnimation.SetBool("Open",true);
            StartCoroutine(Shake(0.5f, 2.0f));
            
        }
        

    }


    public Camera cam;

    public IEnumerator Shake(float _amount, float _duration)
    {
        float timer = 0;
        Vector3 originPos = cam.transform.localPosition;
        while (timer <= _duration)
        {
            cam.transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originPos;



        if(gameObject.name == "Trigger1"){
            conversation[0] = "문이 잠겼어?";
            conversation[1] = "더이상은 돌아갈 수 없겠어. 일단 앞으로 나아가야겠어.";
            Debug.Log(gameObject.name);
            StartCoroutine(talk());
        }

    }

    public GameObject chatPanel;
    public TextMeshProUGUI text;

    string[] conversation = new string[2];
    IEnumerator talk(){
        int textIndex = 0;
        while(conversation.Length > textIndex){

            chatPanel.SetActive(true);
            text.text = conversation[textIndex];
            if(Input.GetKeyDown(KeyCode.Space)) textIndex++;
            yield return new WaitForSeconds(0.0001f);
        }

        chatPanel.SetActive(false);
        gameObject.SetActive(false);
    }

}
