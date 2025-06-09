using System.Collections.Generic;
using UnityEngine;

public class Testplayer1 : Character
{
    void Start()
    {        
        Name = "小黑";
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
}
