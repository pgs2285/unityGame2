using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct CharacterInfo{
    public Sprite characterSprite;
    public string AnimatorControllerName;
    public float Speed;
    public Sprite portrait;
    public Sprite Skill1Image;
    public Sprite Skill2Image;
    
}


public class MainCharacter : MonoBehaviour
{

    bool isCreated_GameOverPanel = true;
    [SerializeField]
    GameObject gameoverPanel;

    UIManager uiManager;
    decimal[] fullExperience = { 10, 20, 40, 80, 160, 320, 640, 1280 };
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        uiManager = GameObject.Find("UI").GetComponent<UIManager>();
        // uiManager = UIManager.Instance.GetComponent<UIManager>();
    }

    protected void isDeath() {
        if (CharacterData.Instance.CurrentHP < 0) { //currentHP가  0보다 작으면
            Debug.Log("GameOver");
            if (isCreated_GameOverPanel) {
                Instantiate(gameoverPanel);
                isCreated_GameOverPanel = false; //추후 버튼에서 다시시작, 종료를 누르면 다시 true로 바꿔줘야함
            }
        }
    }
    protected void getDamage(int damage) {
        CharacterData.Instance.CurrentHP -= damage;
        isDeath(); // 죽었나 확인후 죽었으면 패널띄움

    }

    public float X;
    public float Y;
    public void walk()
    {
        X = Input.GetAxisRaw("Horizontal");
        Y = Input.GetAxisRaw("Vertical");
        if(X == -1) transform.Translate(new Vector2(-X, Y) * Time.deltaTime * CharacterData.Instance.Speed);
        else transform.Translate(new Vector2(X, Y) * Time.deltaTime * CharacterData.Instance.Speed);
       
    }


    Vector3 dirVec;
    GameObject scanObject;
    public GameObject movePanel;
    void Update()
    {

        if (X == -1) { dirVec = Vector3.left; animator.SetBool("move", true); transform.eulerAngles = new Vector3(0, 180, 0);}
        else if (X == 1) { dirVec = Vector3.right; animator.SetBool("move", true); transform.eulerAngles = new Vector3(0, 0, 0); }
        else if (Y == -1) {dirVec = Vector3.down; animator.SetBool("move", true); }
        else if (Y == 1){ dirVec = Vector3.up; animator.SetBool("move", true);}
        else
        {
            animator.SetBool("move", false);
        }
        if (!uiManager.isAction && CharacterData.Instance.IsMove)
        {
            walk();
        }
        //방향을 알려주는 dirVec
        Debug.DrawRay(transform.position, dirVec * 0.7f, new Color(0,1,0));    
        
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, dirVec, 0.7f, LayerMask.GetMask("Object")); //원점좌표, 발사 방향벡터, 도달거리, 검출할 레이어
        if(rayHit.collider != null && Input.GetButtonDown("Jump")){
            scanObject = rayHit.collider.gameObject;
            uiManager.Action(scanObject);
        }
        rayHit = Physics2D.Raycast(transform.position, dirVec, 0.7f, LayerMask.GetMask("Portal")); //원점좌표, 발사 방향벡터, 도달거리, 검출할 레이어

        if (rayHit.collider != null && Input.GetButtonDown("Jump"))
        {
            movePanel.SetActive(true);
        }


        rayHit = Physics2D.Raycast(transform.position, dirVec, 0.7f, LayerMask.GetMask("Item"));

        if(rayHit.collider != null && Input.GetKeyDown(KeyCode.Space))
        {

            rayHit.collider.GetComponent<getItem>().Get();   
        }

        rayHit = Physics2D.Raycast(transform.position, dirVec, 0.7f, LayerMask.GetMask("InteractableObject"));
        if(rayHit.collider != null && Input.GetKeyDown(KeyCode.Space) && OneTime == 0)
        {
            rayHit.collider.GetComponent<RandomIngredient>().GetItem();
            OneTime ++;
        }
        switchingAble();

    }
    public int OneTime = 0;
    
    [SerializeField]
    public CharacterInfo[] characterInfo;

    SpriteRenderer spriteRenderer;
    RuntimeAnimatorController newController;
    public GameObject switcingEffect;

    public float cooldownTime = 5.0f;
    public float filledTime = 0.0f;

    public void switchingAble() { 
        //// questID가 80이면 스위칭 가능하게함 (스킬 2개 받고감)
        if(CharacterData.Instance.questID >= 120 && CharacterData.Instance.IsMove) // 80보다 크면
        {
            /*
                  
                 1. 캐릭터 외형변화                             (O)
                 2. 캐릭터 animation변화                       (O)
                 3. ui 스킬 변화                               (O)
                 4. 마우스 좌,우 클릭시 사용 스킬변화               (O)
                 5. UI main, sub 위치 변화시키기                (O)
                 6. 변화 직후에는 몇초간 스킬 사용 불가하게 만들기   (O)  
       
            */

            if (cooldownTime > filledTime)
            {
                filledTime += Time.deltaTime; //쿨타임일시
               
            }
            else //쿨타임이 아닐때 스킬 사용하게
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {

                    Debug.Log("Switching");
                    int tmp;
                    /// 메인과 서브 위치 바꿔주기
                    tmp = CharacterData.Instance.mainCh;
                    CharacterData.Instance.mainCh = CharacterData.Instance.subCh;
                    CharacterData.Instance.subCh = tmp;
                    //이펙트 생성 후 삭제
                    Instantiate(switcingEffect, this.transform.position, this.transform.rotation);
                    Destroy(switcingEffect, 1.0f);
                    //sprite와 animator변경해주기
                    spriteRenderer = GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = characterInfo[CharacterData.Instance.mainCh].characterSprite;
                    newController = Resources.Load<RuntimeAnimatorController>(characterInfo[CharacterData.Instance.mainCh].AnimatorControllerName);
                    CharacterData.Instance.Speed = characterInfo[CharacterData.Instance.mainCh].Speed;
                    animator.runtimeAnimatorController = newController;
                    filledTime = 0.0f;

                }
                
            }
        }
    
    }

        public GameObject onTheLeg;
        public void GetStun(){
            transform.position = onTheLeg.GetComponent<LegMovement>().startPos;
            animator.SetBool("Stun", false);
            CharacterData.Instance.IsMove = true;

        }


}
