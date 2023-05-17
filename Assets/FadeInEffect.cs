using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInEffect : MonoBehaviour
{
    public GameObject FadeInPanel;

    public void Start(){
        FadeOut();
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCo());
    }
    IEnumerator FadeOutCo(){
        FadeInPanel.SetActive(true);
        CanvasGroup cg = FadeInPanel.GetComponent<CanvasGroup>();
        cg.alpha = 1;
        while(cg.alpha > 0){
            cg.alpha -= Time.deltaTime;
            yield return null;
        }
        FadeInPanel.SetActive(false);
    }
}
