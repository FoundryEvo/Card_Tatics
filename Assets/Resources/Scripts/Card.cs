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
    //��ƬID
    public int CardID { get; private set; } 
    //��Ƭ����
    public string CardName { get; private set; }
    //��Ƭ����
    public CardType CardType { get; private set; }
    //����������
    public CardSubtype CardSubtype { get; private set; }
    //��Ƭ�����ֵ
    public int CardMaxValue { get; private set; }
    //������С��ֵ
    public int CardMinValue { get; private set; }
    //��Ƭ�ʵ�
    public int CardSephiroth { get; private set; }
    //��ƬЧ������
    public string CardEff {  get; private set; }
    //��Ƭ���
    public bool CardRange { get; private set; }

    //���캯��
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

    //public Dictionary<string, string> cardData = new Dictionary<string, string>();  //������Ϣ



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