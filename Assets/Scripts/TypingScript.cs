using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TypingScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] cutSceneScript;
    // Update is called once per frame
    public Image Image;
    public Sprite[] sprite;
    void Start()
    {
        StartCoroutine(_typing());
    }


    IEnumerator _typing()
    {
        
        for (int j = 0; j < cutSceneScript.Length; j++)
        {
            Image.sprite = sprite[j];
            for (int i = 0; i < cutSceneScript[j].Length + 1; i++)
            {
                text.text = cutSceneScript[j].Substring(0,i);
                yield return new WaitForSeconds(0.15f);
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
