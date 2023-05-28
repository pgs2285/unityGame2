using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistAction : MonoBehaviour
{
    public GameObject lightPanel;

    public Camera cam;
    public void LightOnoff(){
        StartCoroutine(LightUp());
    }
    IEnumerator LightUp(){
        lightPanel.SetActive(true);
        StartCoroutine(Shake(1.5f, 1f));
        yield return new WaitForSeconds(0.1f);

        yield return new WaitForSeconds(1f);
        cam.transform.position = new Vector3(0,0,-10);
        Destroy(gameObject);
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
