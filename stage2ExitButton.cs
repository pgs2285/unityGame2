using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class stage2ExitButton : MonoBehaviour
{
    void Update(){
        if(Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < 1.5f){
            Debug.Log("범위안에 들어옴");
            if(Input.GetKeyDown(KeyCode.Space)){
                
                StartCoroutine(Shake(0.5f, 2.0f));
            }
        }
    }
    public Camera cam;
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
        transform.localPosition = originPos;




        conversation[0] = "탈출구가 열린거 같아!?";
        conversation[1] = "빨리 나가야겠어!";
        Debug.Log(gameObject.name);
        StartCoroutine(talk());
        

    }

    public GameObject chatPanel;
    public TextMeshProUGUI text;


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
