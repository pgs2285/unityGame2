using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Talk : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject chatPanel;
    public TextMeshProUGUI text;
    GameObject player;
    GameObject uiManager;
    private void Start() {
        player = GameObject.FindWithTag("Player");
        uiManager = GameObject.Find("UI");
        
    }

    public IEnumerator talk(string[] conversation){
        int textIndex = 0;
        uiManager.GetComponent<UIManager>().isAction = true;
        while(conversation.Length > textIndex){

            CharacterData.Instance.IsMove = false;
            yield return new WaitForSeconds(0.001f);
            // chatPanel.SetActive(true);
            chatPanel.GetComponent<Animator>().SetBool("isShow",true);
            text.text = conversation[textIndex];
            if(Input.GetKeyDown(KeyCode.Space)) textIndex++;

        }
        uiManager.GetComponent<UIManager>().isAction = false;
        // chatPanel.SetActive(false);
        chatPanel.GetComponent<Animator>().SetBool("isShow",false);
        CharacterData.Instance.IsMove = true;
        player.GetComponent<MainCharacter>().OneTime =0;
    }
}
