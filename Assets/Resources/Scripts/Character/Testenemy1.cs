using System.Collections.Generic;
using UnityEngine;

public class Testenemy1 : MonoBehaviour
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


}
