using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.LightAnchor;

public class JumpSkill : MonoBehaviour
{

    public float jumpDistance = 1.0f;
    public float cooldownTime = 2.0f;
    private float filledTime = 0.0f;
    private bool usableSkill = true;
    private WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();
    public Image icon;
    private Vector3 jumpDirection = Vector3.zero;


    private void Start(){
        StartCoroutine("cooltimeCount");
    }
    
    void jumpSkill()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");


            if(X == -1) // 왼쪽 대쉬
            {
                jumpDirection = new Vector3(-jumpDistance, 0,0);
            }else if(X == 1)
            {
                jumpDirection = new Vector3(jumpDistance, 0, 0);
            }
            else if(Y == -1)
            {
                jumpDirection = new Vector3(0, -jumpDistance, 0);
            }
            else if(Y == 1)
            {
                jumpDirection = new Vector3(0, jumpDistance, 0);
            }
            transform.position = transform.position += jumpDirection;
        
    }


    IEnumerator cooltimeCount(){
        
        for(;;){
            if(filledTime < cooldownTime){

                yield return fixedUpdate;
                filledTime += Time.deltaTime;
                icon.fillAmount = filledTime/cooldownTime;

            }else{
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jumpSkill();
                    filledTime = 0.0f;
                    yield break;
                }
            }
        }
        
    }

}

