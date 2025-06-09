using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    //��ɫ����
    public string Name;
    //��ɫ����
    public string Description;
    //��ɫ�������ֵ
    public int MaxHP;
    //��ɫ��ǰ����ֵ
    public int CurrentHP;
    //��ɫ�������ֵ
    public int MaxSan;
    //��ɫ��ǰ����ֵ
    public int CurrentSan;
    //��ɫ״̬
    public Buff CharacterStatus;
    //��ɫ��ʼ�ٶ�
    public int InitSpeed;
    //��ɫ��ǰ�ٶ�
    public int CurrentSpeed;
    //��ɫ��ʼ����
    public int InitArmor;
    //��ɫ��ǰ����
    public int CurrentArmor;
    //��ɫ������
    public int PhysicalResistance;
    //��ɫ���ǿ���
    public int SanityResistance;
    //��ɫӵ�е�Buff
    public List<Buff> Buff;
    //��ɫӵ�е�Debuff
    public List<Debuff> Debuff;
    //��ɫװ����Դ��
    public Orikey EquipOrikey;
    //��ɫ���лغ�������
    public int TurnDice;
    //������������
    public int BonusDice;
    //��ɫ��ǰ�غ�������
    public int CurrentTurnDice;
    //��ɫ����
    public List<Card> HandCard;

    //��ɫ�ж���
    public List<Card> Action;

    //��ɫ�ƿ�
    public Dictionary<int, Card> Deck;
    //��ɫ���ƶ�
    public List<Card> DrawPile;
    //��ɫ���ƶ�
    public List<Card> DiscardPile;
    //��ɫ���Ķ�
    public List<Card> ExhaustPile;


    public Character()
    {
        Name = "";
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
        CurrentHP = maxHP; // ��ʼ��Ϊ�������ֵ
        MaxSan = maxSan;
        CurrentSan = maxSan; // ��ʼ��Ϊ�������ֵ
        InitSpeed = initSpeed;
        CurrentSpeed = initSpeed; // ��ʼ����ǰ�ٶ�
        InitArmor = initArmor;
        CurrentArmor = initArmor; // ��ʼ����ǰ����
        PhysicalResistance = physicalResistance;
        SanityResistance = sanityResistance;
        //Status = CharacterStatus.Normal; // Ĭ��״̬
        //Buff = new List<Buff>(); // ��ʼ�� Buff �б�
        //Debuff = new List<Debuff>(); // ��ʼ�� Debuff �б�
        HandCard = new List<Card>(); // ��ʼ������
        Action = new List<Card>(); // ��ʼ���ж���
        Deck = new Dictionary<int, Card>(); // ��ʼ���ƿ�
        DrawPile = new List<Card>(); // ��ʼ�����ƶ�
        DiscardPile = new List<Card>(); // ��ʼ�����ƶ�
        ExhaustPile = new List<Card>(); // ��ʼ�����Ķ�
        //equipOrikey = equipOrikey; // ��ʼ��װ����Դ��
    }

    void Start()
    {
        
    }
}
