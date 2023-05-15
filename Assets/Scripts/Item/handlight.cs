using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handlight : MonoBehaviour
{
    int light_z = 0;
    // Update is called once per frame
    void Update()
    {

        float z = Input.mousePosition.z - Camera.main.transform.position.z;
        if(Input.GetKey(KeyCode.M)){
            light_z--;
        }
        if(Input.GetKey(KeyCode.N)){
            light_z++;
        }
        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, light_z);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy")) {
            other.gameObject.GetComponent<Enermy_Ai>().isStun = true;
            other.gameObject.GetComponent<Enermy_Ai>().stunLocation = other.gameObject.transform.position;
        }    
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy")) {
            other.gameObject.GetComponent<Enermy_Ai>().isStun = true;
            
            // Debug.Log("적이 스턴상태 입니다");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy")) {
            other.gameObject.GetComponent<Enermy_Ai>().isStun = false;
        }
    }
    
}
