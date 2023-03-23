using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMovement : MonoBehaviour
{

    public float speed = 1f;
    public float moveAmount = 1f;

    void Update() {
        float pingPong = Mathf.PingPong(Time.time * speed, moveAmount * 2) - moveAmount;
        transform.position = new Vector3(transform.position.x, pingPong, transform.position.z);
    }


}
