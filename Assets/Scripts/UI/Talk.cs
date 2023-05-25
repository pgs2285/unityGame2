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
        chatPanel.GetComponent<Animator>().SetBool("isShow",true);
        uiManager.GetComponent<UIManager>().isAction = true;
        CharacterData.Instance.IsMove = false;
        yield return null;
        while(conversation.Length > textIndex){
            yield return null;
 
            text.text = conversation[textIndex];
            if(Input.GetKeyDown(KeyCode.Space)) textIndex++;
        }
        CharacterData.Instance.IsMove = true;
        uiManager.GetComponent<UIManager>().isAction = false;
        // chatPanel.SetActive(false);
        chatPanel.GetComponent<Animator>().SetBool("isShow",false);
        
        player.GetComponent<MainCharacter>().OneTime =0;
    }



}
