using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{

    bool isCreated_GameOverPanel = true;
    [SerializeField]
    GameObject gameoverPanel;

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


    public void walk()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(X, Y) * Time.deltaTime * CharacterData.Instance.Speed);
    }

    public void run()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(X, Y) * Time.deltaTime * CharacterData.Instance.RunSpeed);
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        { // 왼
            run();
        }
        else
        {
            walk();
        }
    }

}
