using System.Collections.Generic;
using UnityEngine;

public class Testplayer1 : Character
{
    void Start()
    {        
        Name = "С��";
        Description = "";
        MaxHP = 10;
        CurrentHP = 10; // ��ʼ��Ϊ�������ֵ
        MaxSan = 20;
        CurrentSan = 20; // ��ʼ��Ϊ�������ֵ
        InitSpeed = 5;
        CurrentSpeed = 5; // ��ʼ����ǰ�ٶ�
        InitArmor = 0;
        CurrentArmor = 0; // ��ʼ����ǰ����
        PhysicalResistance = 0;
        SanityResistance = 0;
        Buff = null; // ��ʼ�� Buff �б�
        Debuff = new List<Debuff>(); // ��ʼ�� Debuff �б�
        HandCard = new List<Card>(); // ��ʼ������
        EquipOrikey = null;
        TurnDice = 2;
        BonusDice = 0;
        CurrentTurnDice = TurnDice + BonusDice;

        HandCard = null;
        Action = null; // ��ʼ���ж���
        Deck = null;// ��ʼ���ƿ�
        DrawPile = null; // ��ʼ�����ƶ�
        DiscardPile = null; // ��ʼ�����ƶ�
        ExhaustPile = null; // ��ʼ�����Ķ�
    }
}
