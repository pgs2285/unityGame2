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
        if(other.gameObject.tag == "AttackRegion") return;
        isActive = false;
        isTriggered = true;
        cam.player = Target.transform;
        StartCoroutine(returnCamera());
    }
    private void OnTriggerStay2D(Collider2D other) {

        isActive=false;
        isTriggered = true;
     
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "AttackRegion") return;
        isActive = true;
        Target.transform.GetChild(0).gameObject.SetActive(isActive);
        Target.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("trigger",false);
        if(isTriggered && GameObject.Find("AnotherWorldAssets") != null)
        {
            Target.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    IEnumerator returnCamera(){
        CharacterData.Instance.IsMove = false;
        yield return new WaitForSeconds(2f);
        
        Target.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("trigger",true);

        yield return new WaitForSeconds(1f);
        CharacterData.Instance.IsMove = true;
        cam.player = player.gameObject.transform;

        // camera return
    }
}
