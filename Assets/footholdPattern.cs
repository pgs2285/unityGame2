using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footholdPattern : MonoBehaviour
{
    public CameraFollow cam;
    public GameObject player;
    public GameObject Target;
    bool isTriggered = false;
    public void Awake(){
        cam = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
        player = GameObject.FindWithTag("Player");
    }
    bool isActive = false;
    private void OnTriggerEnter2D(Collider2D other) {
        isActive = false;
        isTriggered = true;
        cam.player = Target.transform;
        StartCoroutine(returnCamera());
    }
    private void OnTriggerStay2D(Collider2D other) {
        isActive=false;
        isTriggered = true;
        Target.SetActive(isActive);
    }
    private void OnTriggerExit2D(Collider2D other) {
        isActive = true;
        Target.SetActive(isActive);
        if(isTriggered && GameObject.Find("AnotherWorldAssets") != null)
        {
            Target.SetActive(false);
        }
    }

    IEnumerator returnCamera(){
        yield return new WaitForSeconds(2f);
        Target.SetActive(isActive);
  
        yield return new WaitForSeconds(1f);
        cam.player = player.gameObject.transform;
        // camera return
    }
}
