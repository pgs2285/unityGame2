using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{

    bool isCreated_GameOverPanel = true;
    [SerializeField]
    GameObject gameoverPanel;

    public UIManager uiManager;
    decimal[] fullExperience = { 10, 20, 40, 80, 160, 320, 640, 1280 };
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    protected void LevelUp(int level) { //추후 PlayerPrefs.HasKey("Level")로 매개변수 넘겨주면 됨
        if (CharacterData.Instance.Experience > fullExperience[level - 1]) { // 만약 경험치가 요구경험치보다 높으면
            CharacterData.Instance.Level += 1;
            CharacterData.Instance.Experience = 0; // 경험치는 다시 0으로 초기화
        }

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

    public void run()
    {
        X = Input.GetAxisRaw("Horizontal");
        Y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(X, Y) * Time.deltaTime * CharacterData.Instance.RunSpeed);
    }
    Vector3 dirVec;
    GameObject scanObject;
    public GameObject movePanel;
    void Update()
    {
        if (!uiManager.isAction && CharacterData.Instance.IsMove)
        {
            walk();
        }
        if (X == -1) { dirVec = Vector3.left; animator.SetBool("move", true); transform.eulerAngles = new Vector3(0, 180, 0); }
        else if (X == 1) { dirVec = Vector3.right; animator.SetBool("move", true); transform.eulerAngles = new Vector3(0, 0, 0); }
        else if (Y == -1) {dirVec = Vector3.down; animator.SetBool("move", true); }
        else if (Y == 1){ dirVec = Vector3.up; animator.SetBool("move", true);}
        else
        {
            animator.SetBool("move", false);
        }
        //방향을 알려주는 dirVec
        Debug.DrawRay(transform.position, dirVec * 0.7f, new Color(0,1,0));    
        
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, dirVec, 0.7f, LayerMask.GetMask("Object")); //원점좌표, 발사 방향벡터, 도달거리, 검출할 레이어
        if(rayHit.collider != null && Input.GetButtonDown("Jump")){
            Debug.Log("상호작용");
            scanObject = rayHit.collider.gameObject;
            uiManager.Action(scanObject);

        }
        rayHit = Physics2D.Raycast(transform.position, dirVec, 0.7f, LayerMask.GetMask("Portal")); //원점좌표, 발사 방향벡터, 도달거리, 검출할 레이어

        if (rayHit.collider != null && Input.GetButtonDown("Jump"))
        {
            movePanel.SetActive(true);
        }



    }

}
