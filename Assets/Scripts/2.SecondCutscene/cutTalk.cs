using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class cutTalk : MonoBehaviour
{
    public GameObject chatWindow;
    public TextMesh text;

    Vector3 destination = new Vector3(0, -5, 0);


    // Update is called once per frame
    void Start()
    {
        StartCoroutine(chatMotion());
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime);
    }
    IEnumerator chatMotion()
    {

        yield return new WaitForSeconds(3f);
        chatWindow.SetActive(true);
        text.text = "조졌네";
        
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("3.TreeVillage");

    }
}
