using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    protected int MaxHP;
    
    protected int MaxMP;
    
    protected float speed;
    protected float runSpeed;
    protected int AttackPoint;
    protected int Level;
    protected bool isFullLevel;
    protected decimal Experience;
    protected decimal[] fullExperience = {10,20,40,80,160,320,640,1280};
    bool isCreated_GameOverPanel = true;
    [SerializeField]
    protected int CurrentHP;
    [SerializeField]
    protected int CurrentMP;
    [SerializeField]
    GameObject gameoverPanel;


    protected int LevelUp(int level){ //추후 PlayerPrefs.HasKey("Level")로 매개변수 넘겨주면 됨
        if(Experience > fullExperience[level - 1]){ // 만약 경험치가 요구경험치보다 높으면
            Level+=1;
            PlayerPrefs.SetInt("Level", Level);
            Experience = 0; // 경험치는 다시 0으로 초기화
        }
        return Level; 
    }
    protected void isDeath(){
        if(CurrentHP < 0){ //currentHP가  0보다 작으면
            Debug.Log("GameOver");
            if(isCreated_GameOverPanel) {
                Instantiate(gameoverPanel);
                isCreated_GameOverPanel = false; //추후 버튼에서 다시시작, 종료를 누르면 다시 true로 바꿔줘야함
            }
        }
    }
    protected int getDamage(int damage){
        CurrentHP -= damage; 
        isDeath(); // 죽었나 확인후 죽었으면 패널띄움
        return CurrentHP;
    }
    public void Update(){
        isDeath();
    }
}
