using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliff : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    public GameObject onTheLeg;

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && !onTheLeg.GetComponent<LegMovement>().isOntheLeg)
        {
            Debug.Log("Player Fall from the leg");
            other.transform.position = onTheLeg.GetComponent<LegMovement>().startPos;

            
        }
    }
}
