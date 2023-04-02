using System;
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
        shieldSkill();
        LAttack();
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

    public void shieldSkill()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {

            CharacterData.Instance.Shield += 1;
            Debug.Log(CharacterData.Instance.CurrentHP);
            StartCoroutine(returnHP(1));
        }
    }
    IEnumerator returnHP(int shieldAmount)
    {
        yield return new WaitForSeconds(5);
        CharacterData.Instance.Shield -= shieldAmount;
    }

    public GameObject foxLSkill;

    public int stack;

    public void LAttack()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {


            if (mainCharacter.X == 1 && mainCharacter.Y == 0) direction = Vector3.right;
            else if (mainCharacter.X == -1 && mainCharacter.Y == 0) direction = Vector3.left;
            else if (mainCharacter.X == 0 && mainCharacter.Y == 1) direction = Vector3.up;
            else if (mainCharacter.X == 0 && mainCharacter.Y == -1) direction = Vector3.down;
            else if (mainCharacter.X == 1 && mainCharacter.Y == 1) direction = new Vector3(1, 1, 0);
            else if (mainCharacter.X == -1 && mainCharacter.Y == 1) direction = new Vector3(-1, 1, 0);
            else if (mainCharacter.X == 1 && mainCharacter.Y == -1) direction = new Vector3(1, -1, 0);
            else if (mainCharacter.X == -1 && mainCharacter.Y == -1) direction = new Vector3(-1, -1, 0);



            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction.normalized);

            if (CharacterData.Instance.FoxSkillStack < 3)
            {
                GameObject Skill = Instantiate(foxLSkill, transform.position, rotation);
            }else if(CharacterData.Instance.FoxSkillStack == 3)
            {
                StartCoroutine(DashSkill(direction));
                CharacterData.Instance.FoxSkillStack = 0;
            }
 
            
            Debug.Log("Stack : " + CharacterData.Instance.FoxSkillStack);
            
        }
    }
    Rigidbody2D rb2d;
    float dashDistance = 2.0f;
    float dashTime = 0.3f;
    IEnumerator DashSkill(Vector3 direciton)
    {
        /*
        yield return new WaitForSeconds(0);
        Vector3 target = transform.position + direction;
        while (Vector3.Distance(transform.position, target) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction * 2 , 0.5f);
            
            yield return new WaitForFixedUpdate();
            Debug.Log(transform.position + " target : "+ target);
            CharacterData.Instance.IsMove = false;
        }

        CharacterData.Instance.IsMove = true;
        */
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = direciton * dashDistance / dashTime;
        yield return new WaitForFixedUpdate();

    }
}




