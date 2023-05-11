using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SceneController : MonoBehaviour
{
    public GameObject tutorialPanel;
    void Start(){
        tutorialPanel.SetActive(true);
        TextMeshProUGUI TutorialText= tutorialPanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        TutorialText.text = "이동: wasd \n 상호작용 : space \n 공격: 좌,우 클릭";
    }
}
