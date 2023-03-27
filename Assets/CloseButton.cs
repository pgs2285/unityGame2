using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CloseButton : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Stage1;
    public void closeButton()
    {
        Panel.SetActive(false);
    }
    public void Stage1Move(){
        SceneManager.LoadScene("4 BearCave");
    }
    public void Update(){
        if(CharacterData.Instance.QuestID == 80) Stage1.GetComponent<Button>().interactable = true;
    }
}
