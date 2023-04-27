using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class textIndicator : MonoBehaviour
{
   public GameObject chatPanel;
    public TextMeshProUGUI text;

    string[] conversation = new string[2];
    bool endTalk = true;
    bool oneTime = true;
    public IEnumerator talk(string[] conversation){
        int textIndex = 0;
        while(conversation.Length > textIndex){

            chatPanel.SetActive(true);
            if(oneTime) {
                StartCoroutine(ShowText(conversation[textIndex], 0.03f));
                oneTime = false;
                endTalk = false;
            }
            if(Input.GetKeyDown(KeyCode.Space) && endTalk) {
                textIndex++;
                oneTime = true;
            }

            yield return new WaitForSeconds(0.0001f);
        }

        chatPanel.SetActive(false);
        gameObject.SetActive(false);

    }
    IEnumerator ShowText(string talkData, float delayTime)
    {
        for(int i = 0; i <= talkData.Length; i++){
            text.text = talkData.Substring(0, i);
            yield return new WaitForSeconds(delayTime);

        }
        endTalk = true;

    }


}