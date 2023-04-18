using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBear : MonoBehaviour
{
    // Start is called before the first frame update
    float endurance = 1.0f;
    public Transform enduranceBar;
    void Start()
    {
        enduranceBar = (transform.GetChild(0)).transform.GetChild(0);//0 번째 자식은 인내심 바 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
