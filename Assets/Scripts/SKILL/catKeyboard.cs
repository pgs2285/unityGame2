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

    private void Update()
    {

        switch(CharacterData.Instance.mainCh){
            case 0: // 고양이
            
                Attack1();
                CatKAttack(); // 고양이 k  스킬
                
            break;

            case 1: // 여우

                FoxJSKill(); // 여우 j 스킬
                shieldSkill(); // 여우 k 스킬
                
                
                
            break;
        }
        
        
        
        
    }
    public GameObject attackRegion;

    void AttackRegion(){
        attackRegion.SetActive(true);
        if(comboCount == 1) StartCoroutine(waitSecondAttack());

    }

    IEnumerator waitSecondAttack(){
        while(comboCount == 1){
            if(Input.GetMouseButtonDown(0)){
                comboCount = 2;
                animator.SetInteger("ComboCount", comboCount);
            }
            yield return new WaitForSeconds(0.000001f);
        }
        isAttacking = false;
    }

    void EndRegion(){
        attackRegion.SetActive(false);
        if(comboCount == 1){
            comboCount = 0;
            animator.SetInteger("ComboCount", comboCount);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if(comboCount == 2){
            comboCount = 0;
            animator.SetInteger("ComboCount", comboCount);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        end = true;
    }

    private bool isAttacking = false;
    public void Attack1(){
        if(!isAttacking){
            if(Input.GetMouseButtonDown(0)){
                if(mainCamera.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x){ //캐릭터기준 오른쪽 클릭
                        
                    // transform.eulerAngles = new Vector3(0, 180, 0);
                    if(transform.eulerAngles.y == 0){
                        GetComponent<SpriteRenderer>().flipX = true;
                    }
                }
                else{
                    // transform.eulerAngles = new Vector3(0, 0, 0);
                    if(transform.eulerAngles.y == 180){
                        GetComponent<SpriteRenderer>().flipX = true;
                    }
                }
                isAttacking = true;
                comboCount = 1;
                animator.SetInteger("ComboCount", comboCount);
            }

        }
    }
    bool isAttackEnd = false;
    // IEnumerator attack(){
        
    //         comboCount++;
    //         animator.SetInteger("ComboCount", comboCount);
    //         yield return new WaitForSeconds(0.3f);
    //         isAttacking = false;
           
    // }
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
    IEnumerator Dash(Vector2 direction, float distance, float time)
    {
        float elapsedTime = 0f;
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = startPosition + direction * distance;

        while (elapsedTime < time)
        {
            float t = elapsedTime / time;
            transform.position = Vector2.Lerp(startPosition, targetPosition, t * 8);
            elapsedTime += Time.deltaTime;
            CharacterData.Instance.FoxSkillStack = 0;
            yield return null;
        }

        transform.position = targetPosition;
        animator.SetBool("Dash", false);
    }



}




