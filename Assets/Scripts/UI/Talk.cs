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
    private void Start() {
        player = GameObject.FindWithTag("Player");
    }

    public IEnumerator talk(string[] conversation){
        int textIndex = 0;
        while(conversation.Length > textIndex){
            CharacterData.Instance.IsMove = false;
            yield return new WaitForSeconds(0.001f);
            chatPanel.SetActive(true);
            text.text = conversation[textIndex];
            if(Input.GetKeyDown(KeyCode.Space)) textIndex++;

        }

        chatPanel.SetActive(false);
        CharacterData.Instance.IsMove = true;
        player.GetComponent<MainCharacter>().OneTime =0;
    }
}
