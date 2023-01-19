using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class TypingScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] cutSceneScript;
    // Update is called once per frame
    public Image Image;
    public Sprite[] sprite;
    void Start()
    {
        StartCoroutine(cutScene());
    }
    Color color;
    public float time = 0.7f;
    IEnumerator cutScene()
    {
        
        for (int j = 0; j < cutSceneScript.Length; j++)
        {
            Image.sprite = sprite[j];
            color = Image.color;
            color.a = 0;
            while (color.a < 1f)
            {
                color.a += Time.deltaTime / time;
                Image.color = color;
                yield return new WaitForSeconds(0.000001f); // 알파값반환을 위해 매우 작은값
            }

            for (int i = 0; i < cutSceneScript[j].Length + 1; i++)
            {
                text.text = cutSceneScript[j].Substring(0,i);
                yield return new WaitForSeconds(0.12f);
            }
            
            color = Image.color;
            while (color.a > 0f)
            {
                color.a -= Time.deltaTime / time;
                Image.color = color;
                yield return new WaitForSeconds(0.000001f);
            }

        }
        SceneManager.LoadScene("TreeVillage");
        
    }
}
