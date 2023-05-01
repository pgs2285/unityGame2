using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footholdPattern : MonoBehaviour
{
    public CameraFollow cam;
    public GameObject player;
    public GameObject Target;
    public void Awake(){
        cam = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
        player = GameObject.FindWithTag("Player");
    }
    bool isActive = false;
    private void OnTriggerEnter2D(Collider2D other) {
        isActive = false;
        cam.player = Target.transform;
        StartCoroutine(returnCamera());
    }
    private void OnTriggerStay2D(Collider2D other) {
        isActive=false;
        Target.SetActive(isActive);
    }
    private void OnTriggerExit2D(Collider2D other) {
        isActive = true;
        Target.SetActive(isActive);
 
    }

    IEnumerator returnCamera(){
        yield return new WaitForSeconds(2f);
        Target.SetActive(isActive);
  
        yield return new WaitForSeconds(1f);
        cam.player = player.gameObject.transform;
        // camera return
    }
}
