using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum CardType
{
    Attack,
    Defense,
    Evade,
}
public enum CardSubtype
{
    Slash,
    Shoot,
    Magic,
    Block,
    Defense,

}


public abstract class Card
{
    //卡片ID
    public int CardID { get; private set; } 
    //卡片名称
    public string CardName { get; private set; }
    //卡片类型
    public CardType CardType { get; private set; }
    //卡牌亚类型
    public CardSubtype CardSubtype { get; private set; }
    //卡片最大数值
    public int CardMaxValue { get; private set; }
    //卡牌最小数值
    public int CardMinValue { get; private set; }
    //卡片质点
    public int CardSephiroth { get; private set; }
    //卡片效果描述
    public string CardEff {  get; private set; }
    //卡片射程
    public bool CardRange { get; private set; }

    //构造函数
    public Card(int ID, string name, CardType type, CardSubtype subtype, int maxValue, int minValue, int sephiroth, bool range)
    {
        CardID = ID;
        CardName = name;
        CardType = type;
        CardSubtype = subtype;
        CardMaxValue = maxValue;
        CardMinValue = minValue;
        CardSephiroth = sephiroth;
        CardRange = range;
    }

    //public Dictionary<string, string> cardData = new Dictionary<string, string>();  //卡牌信息



    //public void Init(Dictionary<string, string> data)
    //{
    //    this.cardData = data;
    //}
}

public class AttackCard : Card
{
    public AttackCard(int ID, string name, CardType type, CardSubtype subtype, int maxValue, int minValue, int sephiroth, bool range) : base(ID, name, type, subtype, maxValue, minValue, sephiroth, range)
    {
    }
}

public class DefenceCard : Card
{
    public DefenceCard(int ID, string name, CardType type, CardSubtype subtype, int maxValue, int minValue, int sephiroth, bool range) : base(ID, name, type, subtype, maxValue, minValue, sephiroth, range)
    {
    }
}

public class EvadeCard : Card
{
    public EvadeCard(int ID, string name, CardType type, CardSubtype subtype, int maxValue, int minValue, int sephiroth, bool range) : base(ID, name, type, subtype, maxValue, minValue, sephiroth, range)
    {
    }
}