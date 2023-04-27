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
    private void OnTriggerEnter2D(Collider2D other) {
        cam.player = Target.transform;
        StartCoroutine(returnCamera());
    }
    IEnumerator returnCamera(){
        yield return new WaitForSeconds(2f);
        Target.SetActive(false);
        yield return new WaitForSeconds(1f);
        cam.player = player.gameObject.transform;
        // camera return
    }
}
