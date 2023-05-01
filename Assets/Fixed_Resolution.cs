using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fixed_Resolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetResolution();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetResolution()
    {
        int setWidth = 1366;
        int setHeight = 768;
        Screen.SetResolution(setWidth, setHeight,true);
    }
}
