using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.LightAnchor;
using TMPro;
using System;
public class JumpSkill : MonoBehaviour
{

    public float jumpDistance = 1.0f;
    public float cooldownTime = 2.0f;
    public float filledTime = 0.0f;
    private bool usableSkill = true;

    public Image icon;
    private Vector3 jumpDirection = Vector3.zero;
    public TextMeshProUGUI coolTimeIndicator;


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


    public void Update()
    {
        if (filledTime < cooldownTime)
        {
            coolTimeIndicator.gameObject.SetActive(true);
            icon.color = Color.gray;
            filledTime += Time.deltaTime;
            icon.fillAmount = filledTime / cooldownTime;
            coolTimeIndicator.text = Math.Truncate(((cooldownTime - filledTime )* 100) / 100).ToString();

        }
        else
        {
            coolTimeIndicator.gameObject.SetActive(false);
            icon.color = Color.white;
            if (Input.GetKeyDown(KeyCode.Z) && CharacterData.Instance.IsDashAble)
            {
                
                jumpSkill();
                filledTime = 0.0f;

            }
        }
    }
}

