using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CircleCollider2D))]
public class ChildAI : MonoBehaviour
{

    // Start is called before the first frame update

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("영역안에 들어왔습니다.");
            gameObject.GetComponentInParent<Enermy_Ai>().key_ai = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponentInParent<Enermy_Ai>().key_ai = 0;
        }
    }
    private CircleCollider2D circleCollider;

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }
    
    private void OnDrawGizmosSelected()
    {
        if (circleCollider != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position , circleCollider.radius);
        }
    }
    private void Update() {
        OnDrawGizmosSelected();
    }


}


