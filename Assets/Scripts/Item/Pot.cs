using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    bool isActive = false;
    UIManager uiManager;

    void Awake(){
        uiManager = GameObject.Find("UI").GetComponent<UIManager>();

    }
    void Update()
    {
        if(Vector3.Distance(GameObject.FindWithTag("Player").transform.position , transform.position) < 2f  && !uiManager.isAction){
            if(Input.GetKeyDown(KeyCode.Space)){
                // 레시피 패널을 띄운다.
                isActive = !isActive;
                RecipeSystem.Instance.RecipePanel.SetActive(isActive);
                RecipeSystem.Instance.InfoPanel.SetActive(!isActive);
                uiManager.isInteration = isActive;
                CharacterData.Instance.IsMove = !isActive;
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            isActive = false;
            RecipeSystem.Instance.RecipePanel.SetActive(isActive);
            RecipeSystem.Instance.InfoPanel.SetActive(!isActive);
            CharacterData.Instance.IsMove = true;
        }

    }
}

