using System.Collections.Generic;
using UnityEngine;

public class Testenemy1 : MonoBehaviour
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


}
