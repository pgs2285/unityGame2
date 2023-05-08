using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removePanel : MonoBehaviour
{
    void PanelRemove(){
        gameObject.GetComponent<Animator>().SetBool("state",false);
    }
}
