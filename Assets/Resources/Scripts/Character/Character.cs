using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    //角色姓名
    public string Name;
    //角色描述
    public string Description;
    //角色最大生命值
    public int MaxHP;
    //角色当前生命值
    public int CurrentHP;
    //角色最大理智值
    public int MaxSan;
    //角色当前理智值
    public int CurrentSan;
    //角色状态
    public Buff CharacterStatus;
    //角色初始速度
    public int InitSpeed;
    //角色当前速度
    public int CurrentSpeed;
    //角色初始护甲
    public int InitArmor;
    //角色当前护甲
    public int CurrentArmor;
    //角色物理抗性
    public int PhysicalResistance;
    //角色理智抗性
    public int SanityResistance;
    //角色拥有的Buff
    public List<Buff> Buff;
    //角色拥有的Debuff
    public List<Debuff> Debuff;
    //角色装备起源键
    public Orikey EquipOrikey;
    //角色固有回合骰子数
    public int TurnDice;
    //奖励的骰子数
    public int BonusDice;
    //角色当前回合骰子数
    public int CurrentTurnDice;
    //角色手牌
    public List<Card> HandCard;

    //角色行动堆
    public List<Card> Action;

    //角色牌库
    public Dictionary<int, Card> Deck;
    //角色抽牌堆
    public List<Card> DrawPile;
    //角色弃牌堆
    public List<Card> DiscardPile;
    //角色消耗堆
    public List<Card> ExhaustPile;


    public Character()
    {
        Name = "";
        Description = "";
        MaxHP = 10;
        CurrentHP = 10; // 初始化为最大生命值
        MaxSan = 20;
        CurrentSan = 20; // 初始化为最大理智值
        InitSpeed = 5;
        CurrentSpeed = 5; // 初始化当前速度
        InitArmor = 0;
        CurrentArmor = 0; // 初始化当前护甲
        PhysicalResistance = 0;
        SanityResistance = 0;
        Buff = null; // 初始化 Buff 列表
        Debuff = new List<Debuff>(); // 初始化 Debuff 列表
        HandCard = new List<Card>(); // 初始化手牌
        EquipOrikey = null;
        TurnDice = 2;
        BonusDice = 0;
        CurrentTurnDice = TurnDice + BonusDice;

        HandCard = null;
        Action = null; // 初始化行动堆
        Deck = null;// 初始化牌库
        DrawPile = null; // 初始化抽牌堆
        DiscardPile = null; // 初始化弃牌堆
        ExhaustPile = null; // 初始化消耗堆

    }

    public Character(
        string name,
        string description,
        int maxHP,
        int maxSan,
        int initSpeed,
        int initArmor,
        int physicalResistance,
        int sanityResistance,
        Orikey EquipOrikey)
    {
        Name = name;
        Description = description;
        MaxHP = maxHP;
        CurrentHP = maxHP; // 初始化为最大生命值
        MaxSan = maxSan;
        CurrentSan = maxSan; // 初始化为最大理智值
        InitSpeed = initSpeed;
        CurrentSpeed = initSpeed; // 初始化当前速度
        InitArmor = initArmor;
        CurrentArmor = initArmor; // 初始化当前护甲
        PhysicalResistance = physicalResistance;
        SanityResistance = sanityResistance;
        //Status = CharacterStatus.Normal; // 默认状态
        //Buff = new List<Buff>(); // 初始化 Buff 列表
        //Debuff = new List<Debuff>(); // 初始化 Debuff 列表
        HandCard = new List<Card>(); // 初始化手牌
        Action = new List<Card>(); // 初始化行动堆
        Deck = new Dictionary<int, Card>(); // 初始化牌库
        DrawPile = new List<Card>(); // 初始化抽牌堆
        DiscardPile = new List<Card>(); // 初始化弃牌堆
        ExhaustPile = new List<Card>(); // 初始化消耗堆
        //equipOrikey = equipOrikey; // 初始化装备起源键
    }

    void Start()
    {
        
    }
}
