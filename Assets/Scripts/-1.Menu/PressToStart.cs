using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressToStart : MonoBehaviour
{
    public GameObject EyeBlinkEffect;

    private void Start()
    {
        EyeBlinkEffect.SetActive(false);
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
           StartCoroutine(EyeDown()); 
        }   
    }

    IEnumerator EyeDown()
    {
        EyeBlinkEffect.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("0.MainMenu");
    }
}
