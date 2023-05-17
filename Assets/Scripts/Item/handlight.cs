using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handlight : MonoBehaviour
{
    int light_z = 0;
    // Update is called once per frame
    void Update()
    {

        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -10f;
        // 마우스 위치를 월드 좌표계로 변환
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        Debug.Log(worldPosition);
        float zRotation = Mathf.Atan2(worldPosition.y - transform.position.y, worldPosition.x - transform.position.x) * Mathf.Rad2Deg; 
        // mathf -> 각도 단위를 라디안에서 도로 변환하기
        // atan2 = 두점사이의 탄젠트값을 받아 절대각을 라디안으로 반환함(-180 ~ 180)
        // atan - 동일하지만 각도 범위가 -90~90

        transform.rotation = Quaternion.Euler(0, 0, zRotation);


        // if(Input.GetKey(KeyCode.M)){
        //     light_z--;
        // }
        // if(Input.GetKey(KeyCode.N)){
        //     light_z++;
        // }
        // transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, light_z);
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
