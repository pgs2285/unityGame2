using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HoneyBEE : MonoBehaviour
{

    public float Guage = 5;
    public float currentGuage=0;

    public GameObject guageBarObject;
    GameObject canvas;
    RectTransform GuageBar;
    GameObject prfGuageBar;
    public float height = 1.0f;
    private void Start(){

        canvas = GameObject.Find("UI");
        prfGuageBar = Instantiate(guageBarObject, canvas.transform);
        GuageBar = prfGuageBar.GetComponent<RectTransform>();
    }
    IEnumerator beeGenerate(){
        yield return new WaitForSeconds(0.5f);
        GameObject bee = Instantiate(Resources.Load("Prefab/bee"),transform.position + new Vector3(1, Random.Range(-1.0f,1.0f),0), Quaternion.identity) as GameObject;

    }
    private void Update(){
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * height);
        GuageBar.position = _hpBarPos;
    }
    float time;
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            // 스페이스를 5초간 누르고 있으면 벌 1마리 소환?
            if(Input.GetKey(KeyCode.Space)){
                currentGuage += Time.deltaTime;
                GuageBar.GetChild(0).GetComponent<Image>().fillAmount = currentGuage / Guage;
                if(currentGuage >= 5.0f){
                    StartCoroutine(beeGenerate());
                    
                    currentGuage = 0;
                }
            }

        }
    }
}
