using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoor : MonoBehaviour
{
    public GameObject Light;
    void Update()
    {
        if(CharacterData.Instance.QuestID == 81)
        {
            Light.SetActive(true);
           
        }    
    }
}
