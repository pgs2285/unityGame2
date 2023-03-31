using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catKeyboard : MonoBehaviour
{
    public float comboResetTime = 1.0f; // 콤보 리셋 시간
    private float lastAttackTime = 0.0f; // 마지막 공격 시간
    private int comboCount = 0; // 현재 콤보 수
    private Animator animator;

    private MainCharacter mainCharacter;

    private void Start()
    {
        animator = GetComponent<Animator>();
        mainCharacter = GetComponent<MainCharacter>();
    }
 

    private void Update()
    {
        jKeyBoard();
        kKeyboard();
    }

    public void jKeyBoard(){
        if (Input.GetKeyDown(KeyCode.J) || comboCount > 0)
        {
            Debug.Log("Enter Successfully");
            CharacterData.Instance.IsMove = false;
            Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1), 0);
            // if(mainCamera.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x){ //오른쪽클릭시
                
            //     transform.eulerAngles = new Vector3(0, 180, 0);
                
            // }
            // else{
            //     transform.eulerAngles = new Vector3(0, 0, 0);
            // }

            if (comboCount == 0) lastAttackTime = Time.time; // 처음 들어올때만 찍혀야함
    
            if (Time.time - lastAttackTime < comboResetTime)
            {
                if (Input.GetKeyDown(KeyCode.J)) comboCount++;
            }
            else
            {
                comboCount = 0;
            }

            if (comboCount >= 3)
            {
                comboCount = 0;
            }
            // 애니메이션 트리거 설정
            animator.SetInteger("ComboCount", comboCount);
        }else CharacterData.Instance.IsMove = true;
    }
    public GameObject objectPrefab; // 생성할 오브젝트 프리팹
    public Camera mainCamera; // 메인 카메라
    Vector3 direction = new Vector3(0,0,0);
    public void kKeyboard(){
       if (Input.GetKeyDown(KeyCode.K))
        {   

            
            if(mainCharacter.X == 1 && mainCharacter.Y == 0) direction = Vector3.right;
            else if(mainCharacter.X == -1 && mainCharacter.Y == 0) direction = Vector3.left;
            else if(mainCharacter.X == 0 && mainCharacter.Y == 1) direction = Vector3.up;
            else if(mainCharacter.X == 0 && mainCharacter.Y == -1)direction = Vector3.down;
            else if(mainCharacter.X == 1 && mainCharacter.Y == 1) direction = new Vector3(1,1,0);
            else if(mainCharacter.X == -1 && mainCharacter.Y == 1) direction = new Vector3(-1,1,0);
            else if(mainCharacter.X == 1 && mainCharacter.Y == -1) direction = new Vector3(1,-1,0);
            else if(mainCharacter.X == -1 && mainCharacter.Y == -1) direction = new Vector3(-1,-1,0);
            

            
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction.normalized);

            Instantiate(objectPrefab, transform.position , rotation);
        }
    }
}




