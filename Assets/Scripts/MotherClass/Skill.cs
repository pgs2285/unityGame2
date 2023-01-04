using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    //클래스 필요 변수
    protected bool isRecycleTime = true;
    protected bool isMana = true;
    protected string skill_id;
    protected int skill_type;
    protected int mana;
    protected int max_mana;
    protected int mana_cost;
    protected decimal skill_cooltime;
    protected int skill_demage;
    protected int skill_range;
    protected bool isTarget = true;
    protected int monster_hp;
    
    protected void Damage_application(int skill_demage,int monster_hp)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Input.GetMouseButton(0))
        {
            //if (Physics.Raycast(transform.position, transform.forward, out hit, skill_range, GameObject<Enermy>))
            //{
            //    if (monster_hp < skill_demage)
            //        Debug.Log("몬스터가 죽었습니다");
            //    else
            //        Debug.Log(skill_demage, "만큼 데미지를 입혔습니다.");
            //}
        }
        

    }
}
