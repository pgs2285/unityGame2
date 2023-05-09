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
    float dashDistance = 2.0f;
    float dashTime = 0.3f;
    float dashTimer = 0.0f;

    private MainCharacter mainCharacter;

    private void Start()
    {
        animator = GetComponent<Animator>();
        mainCharacter = GetComponent<MainCharacter>();
    }
    
    public float catJCoolTime = 0;
    public float catKCoolTime = 2;
    public float foxJCoolTime = 2;
    public float foxKCoolTime = 10;

    public float catjFilledTime = 0;
    public float catkFilledTime = 0;
    public float foxjFilledTime = 0;
    public float foxkFilledTime = 0;

    bool end = false;
    Coroutine coroutine;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            animator.SetBool("Dash", true);

        }

        switch(CharacterData.Instance.mainCh){
            case 0: // 고양이
                

                CatKAttack(); // 고양이 k  스킬
                
            break;

            case 1: // 여우

                FoxJSKill(); // 여우 j 스킬
                shieldSkill(); // 여우 k 스킬
                
            break;
        }
        
        
    
        
    }
    public void SetAttack(){
        time = 0f;
        StartCoroutine(ComboAtk());
    }
    float speed = 0.5f;
    float maxTime = 1f;
    float minTime = 0.4f;
    float time = 0f;
    int AtkNum = 0;
    bool isAtk = false;
    IEnumerator ComboAtk(){
        yield return null;
        while(!(Input.GetMouseButtonDown(0))){
            time += Time.deltaTime * speed;
            Debug.Log(time);
            yield return null;
        }
        if(time <= maxTime){
            animator.SetFloat("Blend", AtkNum++);
            animator.SetTrigger("Attack");
            if(AtkNum < 2){
                SetAttack();
            }else{
                AtkNum = 0;
                isAtk = false;
            }
        }
        else{
            animator.SetFloat("Blend", 0);
            animator.SetTrigger("Attack");
            isAtk = false;
            AtkNum = 0;
        }
        time = 0;

    }
    public GameObject attackRegion;

    void AttackRegion(){
        attackRegion.SetActive(true);
    }
    void EndRegion(){
        attackRegion.SetActive(false);
    }

    private bool isAttacking = false;

    public GameObject objectPrefab; // 생성할 오브젝트 프리팹
    public Camera mainCamera; // 메인 카메라
    Vector3 direction = new Vector3(0,0,0);
    public void FoxJSKill(){
        if(foxJCoolTime >= foxjFilledTime){
            foxjFilledTime += Time.deltaTime;
        }else{
            if (Input.GetKeyDown(KeyCode.J))
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
                    foxjFilledTime = 0;
                }
        }
    }

    public void shieldSkill()
    {
        if(foxKCoolTime >= foxkFilledTime){
            foxkFilledTime += Time.deltaTime;
        }else{
            if (Input.GetKeyDown(KeyCode.K))
            {

                CharacterData.Instance.Shield += 3;
           
                StartCoroutine(returnHP(3));
                foxkFilledTime = 0;
            }
        }

    }
    IEnumerator returnHP(int shieldAmount)
    {
        yield return new WaitForSeconds(5);
        CharacterData.Instance.Shield -= shieldAmount;
    }

    public GameObject foxLSkill;

    public int stack;
    bool isDashing = true;
    public void CatKAttack()
    {

        if(catKCoolTime >= catkFilledTime)
        {
            catkFilledTime += Time.deltaTime;
        }else{
            if (Input.GetKeyDown(KeyCode.K))
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

                if (CharacterData.Instance.FoxSkillStack < 2)
                {
                    GameObject Skill = Instantiate(foxLSkill, transform.position, rotation);
                }else if(CharacterData.Instance.FoxSkillStack >= 2)
                {
                    animator.SetBool("Dash", true);
                    StartCoroutine(Dash(direction, 3.0f, 0.8f));
                }
                catkFilledTime = 0;
        
            }

                
        }
    }
    void DashSkill(){

        if (mainCharacter.X == 1 && mainCharacter.Y == 0) direction = Vector3.right;
        else if (mainCharacter.X == -1 && mainCharacter.Y == 0) direction = Vector3.left;
        else if (mainCharacter.X == 0 && mainCharacter.Y == 1) direction = Vector3.up;
        else if (mainCharacter.X == 0 && mainCharacter.Y == -1) direction = Vector3.down;
        else if (mainCharacter.X == 1 && mainCharacter.Y == 1) direction = new Vector3(1, 1, 0);
        else if (mainCharacter.X == -1 && mainCharacter.Y == 1) direction = new Vector3(-1, 1, 0);
        else if (mainCharacter.X == 1 && mainCharacter.Y == -1) direction = new Vector3(1, -1, 0);
        else if (mainCharacter.X == -1 && mainCharacter.Y == -1) direction = new Vector3(-1, -1, 0);
        StartCoroutine(Dash(direction, 1.5f, 1.5f));

    }
    void DashEnd(){
        animator.SetBool("Dash", false);
    }
    IEnumerator Dash(Vector2 direction, float distance, float time)
    {
        float elapsedTime = 0f;
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = startPosition + direction * distance;

        while (elapsedTime < time && animator.GetBool("Dash"))
        {
            float t = elapsedTime / time;
            transform.position = Vector2.Lerp(startPosition, targetPosition, t * 8);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

    }



}




