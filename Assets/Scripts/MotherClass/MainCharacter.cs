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
    protected void LevelUp(int level){ //추후 PlayerPrefs.HasKey("Level")로 매개변수 넘겨주면 됨
        if(CharacterData.Instance.Experience > fullExperience[level - 1]){ // 만약 경험치가 요구경험치보다 높으면
            CharacterData.Instance.Level +=1;
            CharacterData.Instance.Experience = 0; // 경험치는 다시 0으로 초기화
        }

    }
    protected void isDeath(){
        if(CharacterData.Instance.CurrentHP < 0){ //currentHP가  0보다 작으면
            Debug.Log("GameOver");
            if(isCreated_GameOverPanel) {
                Instantiate(gameoverPanel);
                isCreated_GameOverPanel = false; //추후 버튼에서 다시시작, 종료를 누르면 다시 true로 바꿔줘야함
            }
        }
    }
    protected void getDamage(int damage){
        CharacterData.Instance.CurrentHP -= damage; 
        isDeath(); // 죽었나 확인후 죽었으면 패널띄움

    }

    float X;
    float Y;
    public void walk()
    {
        X = Input.GetAxisRaw("Horizontal");
        Y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(X, Y) * Time.deltaTime * CharacterData.Instance.Speed);
    }

    public void run()
    {
        X = Input.GetAxisRaw("Horizontal");
        Y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(X, Y) * Time.deltaTime * CharacterData.Instance.RunSpeed);
    }
    Vector3 dirVec;
    GameObject scanObject;
    void Update()
    {   
        if( X == -1) dirVec = Vector3.left;
        else if(X == 1) dirVec = Vector3.right;
        else if(Y == -1) dirVec = Vector3.down;
        else if(Y == 1) dirVec = Vector3.up;
        //방향을 알려주는 dirVec
        Debug.DrawRay(transform.position, dirVec * 0.7f, new Color(0,1,0));    
        
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, dirVec, 0.7f, LayerMask.GetMask("Object")); //원점좌표, 발사 방향벡터, 도달거리, 검출할 레이어
        if(rayHit.collider != null && Input.GetButtonDown("Jump")){
            scanObject = rayHit.collider.gameObject;
            uiManager.Action(scanObject);

        }


        if(!uiManager.isAction){
            walk();
        }

    }

}
