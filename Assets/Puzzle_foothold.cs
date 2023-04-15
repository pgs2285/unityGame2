using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_foothold : MonoBehaviour
{

    public GameObject Door;
    void OnTriggerEnter2D(Collider2D other)
    {
       //추후 소리호출
        StartCoroutine(Shake(0.3f, 0.5f));
        Door.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //추후 소리호출
        Door.SetActive(false);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(Shake(0.3f, 0.5f));
        //추후 소리호출
        Door.SetActive(true);
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
        // transform.localPosition = originPos;
        // gameObject.SetActive(false);
    }
}
