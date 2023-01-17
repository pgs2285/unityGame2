using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TypingScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] cutSceneScript;
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(_typing());
    }

    IEnumerator _typing()
    {
        
        for (int j = 0; j < cutSceneScript.Length; j++)
        {
            for (int i = 0; i < cutSceneScript[j].Length + 1; i++)
            {
                text.text = cutSceneScript[j].Substring(0,i);
                yield return new WaitForSeconds(0.15f);
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
