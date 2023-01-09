using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{   
    [SerializeField]
    private GameObject hpBar;
    [SerializeField]
    private GameObject mpBar;
    [SerializeField]
    private TextMeshProUGUI level;
    
    [SerializeField]
    private TextMeshProUGUI nowEXP;

    [SerializeField]
    private TextMeshProUGUI fullEXP;

    [SerializeField]
    private GameObject infoPanel;

    [SerializeField]
    private TextMeshProUGUI attackPoint;

    [SerializeField]
    private TextMeshProUGUI speed;



    private int limitHP=10;
    private int limitMP=10;

    public void Start(){
        infoPanel.SetActive(false);
    }
    public void Update(){
        for(int i = 0; i < CharacterData.Instance.CurrentHP; i++){
            hpBar.transform.GetChild(i).gameObject.SetActive(true);
        }
        for(int i = CharacterData.Instance.CurrentHP; i < limitHP; i++){
            hpBar.transform.GetChild(i).gameObject.SetActive(false);
        }
        for(int i = 0; i < CharacterData.Instance.CurrentMP; i++){
            mpBar.transform.GetChild(i).gameObject.SetActive(true);
        }
        for(int i = CharacterData.Instance.CurrentMP; i < limitMP; i++){
            mpBar.transform.GetChild(i).gameObject.SetActive(false);
        }
        
        level.text = CharacterData.Instance.Level.ToString();
        nowEXP.text = CharacterData.Instance.Experience.ToString();
        fullEXP.text = CharacterData.Instance.fullExperience[CharacterData.Instance.Level - 1].ToString();

        
    }


    public void activeExtraInfo(){
        if(infoPanel.activeSelf == false){
            infoPanel.SetActive(true);
            attackPoint.text = CharacterData.Instance.AttackPoint.ToString();
            
            speed.text = CharacterData.Instance.Speed.ToString();

        }else{
            infoPanel.SetActive(false);
        }
    }

    [SerializeField] TextMeshProUGUI chatText;
    GameObject scanObject;
    [SerializeField] GameObject chatPanel;
    public bool isAction = false;
    public void Action(GameObject scanObj){
        if(!isAction){
            isAction = true;
            scanObject = scanObj;
            chatPanel.SetActive(true);
            chatText.text = "My Name is " + scanObject.name;
        }else{
            chatPanel.SetActive(false);
            isAction = false;
        }
    }
}
