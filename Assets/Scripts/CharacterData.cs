using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : Singleton<CharacterData>
{
    int maxHP = 4;
    public int MaxHP
    {
        get { return maxHP; }
        set { maxHP = value; }
    }
    int maxMP = 4;
    public int MaxMP
    {
        get { return maxMP; }
        set { maxMP = value; }
    }

    float speed = 4f;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    float runSpeed = 6f;
    public float RunSpeed
    {
        get { return runSpeed; }
        set { runSpeed = value; }
    }
    int attackPoint = 2;
    public int AttackPoint
    {
        get { return attackPoint; }
        set { attackPoint = value; }
    }
    int level = 1;
    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    bool isFullLevel = false;
    public bool IsFullLevel
    {
        get { return isFullLevel; }
        set { isFullLevel = value; }
    }
    decimal experience = 0;
    public decimal Experience
    {
        get { return experience; }
        set { experience = value; }
    }

    
  

    int currentHP = 4;
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

    void Start()
    {
        if (PlayerPrefs.HasKey("MaxHP"))
        {
            CurrentHP = PlayerPrefs.GetInt("MaxHP");
        }
        if (PlayerPrefs.HasKey("CurrentHP"))
        {
            CurrentHP = PlayerPrefs.GetInt("CurrentHP");
        }
        if (PlayerPrefs.HasKey("MaxMP"))
        {
            CurrentHP = PlayerPrefs.GetInt("MaxMP");
        }
        if (PlayerPrefs.HasKey("CurrentMP"))
        {
            CurrentHP = PlayerPrefs.GetInt("CurrentMP");
        }
        if (PlayerPrefs.HasKey("Speed"))
        {
            CurrentHP = PlayerPrefs.GetInt("Speed");
        }
        if (PlayerPrefs.HasKey("RunSpeed"))
        {
            CurrentHP = PlayerPrefs.GetInt("RunSpeed");
        }
        if (PlayerPrefs.HasKey("AttackPoint"))
        {
            CurrentHP = PlayerPrefs.GetInt("AttackPoint");
        }
        if (PlayerPrefs.HasKey("Experience"))
        {
            CurrentHP = PlayerPrefs.GetInt("Experience");
        }

    }

}
