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
    public GameObject monsterWave;
    textIndicator TextIndicator;
    void Awake(){
        TextIndicator = GameObject.Find("EtcController").GetComponent<textIndicator>();
    }
    string[] conversation = new string[2];
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
        
        if(gameObject.name == "Trigger2") Destroy(gameObject);  
        if(gameObject.name == "Trigger3") monsterWave.SetActive(true);

        if(gameObject.name == "Trigger1"){
            conversation[0] = "문이 잠겼어?";
            conversation[1] = "더이상은 돌아갈 수 없겠어. 일단 앞으로 나아가야겠어.";
            Debug.Log(gameObject.name);
            StartCoroutine(TextIndicator.talk(conversation));
        }

    }

 
}
