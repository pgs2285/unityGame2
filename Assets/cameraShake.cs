using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public Camera cam;
    void Start(){

    }

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

    }
}
