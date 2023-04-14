using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterNseconds : MonoBehaviour
{
    public float seconds = 0.5f;

    public void Start(){
        Destroy(gameObject, seconds);
    }
}
