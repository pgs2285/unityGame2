using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : Singleton<CharacterData>
{
    int maxHP = 6;
    bool isMove = true;
    // bool isDashAble = false;
    int hungry = 10;
    public float catjAttackPoint = 1f;
    public float catkAttackPoint = 2f;
    public float foxjAttackPoint = 5f;
    
    bool[] isAttackRuneOpened = new bool[2];
    public bool[] IsAttackRuneOpened { get; set; } = new bool[2];

    bool[] isSpeedRuneOpened = new bool[4];
    public bool[] IsSpeedRuneOpened { get; set; } = new bool[3];

    bool[] foxShieldSkillRuneOpened = new bool[3];
    public bool[] FoxShieldSkillRuneOpened { get; set; } = new bool[3];

    bool[] foxAttackSkillRuneOpened = new bool[3];
    public bool[] FoxAttackSkillRuneOpened { get; set; } = new bool[3];
    
    public int mainCh = 0;
    public int subCh = 1;

    int rp = 6;
    public int RP { get { return rp; } set { rp = value; } }

    int foxSkillStack = 0;
    public int FoxSkillStack { get { return foxSkillStack; } set { foxSkillStack = value; } } 

    int shield = 0;
    public int Shield { get { return shield; } set { shield = value; } }
    bool isAttackAble = true;
    public bool IsAttackAble { get { return isAttackAble; } set { isAttackAble = value; } }
    public int Hungry
    {
        get { return hungry; }
        set { hungry = value; }
    }

    // public bool IsDashAble
    // {
    //     get { return isDashAble; }
    //     set { isDashAble = value; }
    // }
    public bool IsMove
    {
        get { return isMove; }
        set { isMove = value; }
    }

    public int MaxHP
    {
        get { return maxHP; }
        set { maxHP = value; }
    }

    float speed = 3f;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    int attackPoint = 2;
    public int AttackPoint
    {
        get { return attackPoint; }
        set { attackPoint = value; }
    }




    int currentHP = 5;
    public int CurrentHP
    {
        get { return currentHP; }
        set { currentHP = value; }
    }
    int currentMP = 4;
    public int CurrentMP
    {
        get { return currentMP; }
        set { currentMP = value; }
    }

    public int questID = 10;
    public int QuestID
    {
        get { return questID; }
        set { questID = value; }
    } 


    void Start()
    {

    }

}
