using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anotherWorldPortal : MonoBehaviour
{
public Transform cameraTransform;
    void Awake(){
        cameraTransform = Camera.main.transform;
    }
    public nowStage now_Stage;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            switch(now_Stage){
                case nowStage.stage1:
                    StartCoroutine(switchingWorld());
                break;
            }
        }
        else{
            Transform parent = other.gameObject.transform.parent;

            if(parent != null){
                if(parent.gameObject == AnotherWorldEffects){
                    other.gameObject.transform.SetParent(NormalWorldEffects.transform);
                    other.gameObject.transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y - 2f);
                    Debug.Log(other.gameObject.name);
                }
                else if(parent.gameObject == NormalWorldEffects){
                    other.gameObject.transform.SetParent(AnotherWorldEffects.transform);
                }
            }
        }
    }
    public GameObject AnotherWorldEffects;
    bool worldSelect = false;
    public GameObject NormalWorldEffects;
    IEnumerator switchingWorld(){
        yield return new WaitForFixedUpdate();
        Vector3 cameraEulerAngles = cameraTransform.eulerAngles;

        while(angle<130){
            angle++;
            cameraEulerAngles.x = angle;
            cameraTransform.eulerAngles = cameraEulerAngles;
            yield return new WaitForSeconds(0.00001f);
        }
        
        AnotherWorldEffects.SetActive(!worldSelect);
        NormalWorldEffects.SetActive(worldSelect);
        worldSelect = !worldSelect;
        if(angle >= 130){
            while(angle != 0){
            angle--;
            cameraEulerAngles.x = angle;
            cameraTransform.eulerAngles = cameraEulerAngles;
            yield return new WaitForSeconds(0.00001f);
            }
        }
        angle = 0;
        cameraTransform.eulerAngles = cameraEulerAngles;
        cameraEulerAngles.x = angle;

    }
    int angle = 0;
}
public enum nowStage{
    stage1,
    stage2,
    stage3,
    stage4
}