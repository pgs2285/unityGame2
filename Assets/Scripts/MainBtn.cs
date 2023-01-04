using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainBtn : MonoBehaviour
{
   public BtnType currentType;
   public Scene startScene;
   public void clickButton(){
        switch (currentType)
        {   
            case BtnType.New:
            SceneManager.LoadScene("TreeVillage");
            Debug.Log("New Game");
            break;

            case BtnType.Continue:
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
