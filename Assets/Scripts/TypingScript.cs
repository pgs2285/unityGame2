﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TypingScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] cutSceneScript;
    // Update is called once per frame
    public Image Image;
    // public Sprite[] sprite;
    public GameObject FadeOutPanel;

    public VolumeProfile profile;
    void Start()
    {
        StartCoroutine(cutScene());
    }
    Color color;
    public float time = 0.7f;
    Coroutine coroutine;
    public GameObject pist;
    public GameObject FoxLight;
    IEnumerator cutScene()
    {
        coroutine = StartCoroutine(FadeIn());
        yield return new WaitForSeconds(3f);
        for (int j = 0; j < cutSceneScript.Length; j++)
        {

            for (int i = 0; i < cutSceneScript[j].Length + 1; i++)
            {
                text.text = cutSceneScript[j].Substring(0,i);
                yield return new WaitForSeconds(0.1f);
            }
            
            yield return new WaitForSeconds(2f);
        }
        StopCoroutine(coroutine);
        pist.SetActive(true);
        FadeOutPanel.GetComponent<Image>().color = new Color(0,0,0,0);

        yield return new WaitForSeconds(2.2f);
        FoxLight.SetActive(true);
        StartCoroutine(waitLight());
        cutSceneScript[0] = "누구냐?!";
        cutSceneScript[1] = "거의다 끝났었는데... 아쉽게됐어..";
        cutSceneScript[2] = "지금은 물러가지만 이게 끝이아닌걸 명심해라.";
        cutSceneScript[3] = "";
        for (int j = 0; j < cutSceneScript.Length; j++)
        {

            for (int i = 0; i < cutSceneScript[j].Length + 1; i++)
            {
                text.text = cutSceneScript[j].Substring(0,i);
                yield return new WaitForSeconds(0.1f);
            }
            
            yield return new WaitForSeconds(2f);
        }
        
        // SceneManager.LoadScene("2.secondCutScene");

    }

    IEnumerator waitLight(){
        
        yield return new WaitForSeconds(4.5f);
        if(profile.TryGet(out Bloom bloom)){
            while (true){
                bloom.intensity.value += 200f;
                yield return new WaitForSeconds(0.01f);
                if(bloom.intensity.value >= 100000.5f){
                    Debug.Log("Scene Changed");
                    bloom.intensity.value = 3;
                    SceneManager.LoadScene("0.StartMap");

                    break;
                    
                }
            }
        }
    }
    
    IEnumerator FadeIn(){
        FadeOutPanel.GetComponent<Image>().color = new Color(0,0,0,1);
        while(true){
            while(FadeOutPanel.GetComponent<Image>().color.a >= 0.6f && FadeOutPanel.GetComponent<Image>().color.a <= 1.1f)
            {
                FadeOutPanel.GetComponent<Image>().color -= new Color(0, 0, 0, 0.003f);
                yield return new WaitForSeconds(0.01f);
            }
            // 서서히 페이드인
            while(FadeOutPanel.GetComponent<Image>().color.a <= 0.8f && FadeOutPanel.GetComponent<Image>().color.a >= 0.3f)
            {
                FadeOutPanel.GetComponent<Image>().color += new Color(0, 0, 0, 0.003f);
                yield return new WaitForSeconds(0.01f);
            }
            yield return null;
        
        }

    }
}
