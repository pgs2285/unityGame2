using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catRightClickAttack : MonoBehaviour
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
        LeftClick();
        RightClick();
        shieldSkill();
    }

    public void LeftClick(){
        if (Input.GetMouseButtonDown(0) || comboCount > 0)
        {

            CharacterData.Instance.IsMove = false;
            Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1), 0);

            if(mainCamera.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x){ //캐릭터기준 오른쪽 클릭
                
                transform.eulerAngles = new Vector3(0, 180, 0);
                
            }
            else{
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
    
            if (Time.time - lastAttackTime < comboResetTime)
            {
               
                if (Input.GetMouseButtonDown(0)) comboCount++;
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
            if (comboCount == 0) lastAttackTime = Time.time; // 처음 들어올때만 찍혀야함
            animator.SetInteger("ComboCount", comboCount);
        }else CharacterData.Instance.IsMove = true;
    }
    public GameObject objectPrefab; // 생성할 오브젝트 프리팹
    public Camera mainCamera; // 메인 카메라
    public void RightClick(){
       if (Input.GetMouseButtonDown(1))
        {   
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePosition - transform.position;
            
            if(mainCamera.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x){ //오른쪽클릭시
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else{
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

            float angle = Vector3.Angle(transform.right, direction);
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction.normalized);

            Instantiate(objectPrefab, transform.position , rotation);
        }
    }

    public void shieldSkill()
    {
        if (Input.GetMouseButtonDown(2))
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
}




