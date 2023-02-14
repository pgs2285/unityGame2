using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondCutScene : MonoBehaviour
{

    public GameObject light;

    IEnumerator moveLight()
    {
        yield return new WaitForSeconds(3.0f);
        while (true) {
            light.transform.position = Vector3.MoveTowards(light.transform.position, new Vector3(0, 10, 0), 0.001f);
        }
        
    }

    // Update is called once per frame
    void Start()
    {
        
        light.transform.position = Vector3.MoveTowards(light.transform.position, new Vector3(0, 10, 0), 0.001f);

    }
}
