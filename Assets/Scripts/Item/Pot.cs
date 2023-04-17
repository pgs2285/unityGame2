using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    bool isActive = false;
    void Update()
    {
        if(Vector3.Distance(GameObject.FindWithTag("Player").transform.position , transform.position) < 2f){
            if(Input.GetKeyDown(KeyCode.Space)){
                // 레시피 패널을 띄운다.
                isActive = !isActive;
                RecipeSystem.Instance.RecipePanel.SetActive(isActive);
            }
        }
    }
}
