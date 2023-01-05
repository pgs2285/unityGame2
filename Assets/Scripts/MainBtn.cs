using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainBtn : MonoBehaviour
{
    public int a = 0;
   public BtnType currentType;
   public Scene startScene;
   public void clickButton(){
        switch (currentType)
        {   
            case BtnType.New: // 0
            SceneManager.LoadScene("TreeVillage");
            Debug.Log("New Game");
            break;

            case BtnType.Continue: // 1 
            Debug.Log("Continue");
            break;

            case BtnType.Option:
            Debug.Log("Option");
            break;

            case BtnType.Back:
            Debug.Log("Back");
            break;

            case BtnType.Quit:
            Application.Quit();
            Debug.Log("Quit");
            break;
            
        }
   }
}
