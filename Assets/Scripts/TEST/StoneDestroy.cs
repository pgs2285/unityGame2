using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDestroy : MonoBehaviour
{
    void Awake(){
        Destroy(gameObject,3);
    }

}
