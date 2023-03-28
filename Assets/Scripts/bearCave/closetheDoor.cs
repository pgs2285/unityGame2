using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closetheDoor : MonoBehaviour
{


    public Animator LeftdoorAnimation;
    public Animator RightdoorAnimation;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Player") {

            LeftdoorAnimation.SetBool("Open",true);
            RightdoorAnimation.SetBool("Open",true);
            StartCoroutine(Shake(0.5f, 2.0f));
            
        }
    }


    public Camera cam;

    public IEnumerator Shake(float _amount, float _duration)
    {
        float timer = 0;
        Vector3 originPos = cam.transform.localPosition;
        while (timer <= _duration)
        {
            cam.transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originPos;
        gameObject.SetActive(false);
    }
}
