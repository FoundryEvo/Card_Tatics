using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum BattleStep
{
    None,
    Init,
    Speed,
    Win,
    Lose,
    Battle,
    Selecting
}

public class BattleMgr : Singleton<BattleMgr>
{
    //ս����Ԫ
    public FightUnit fightunit;

    //������Ϸ�ǳ��ĵ���˫���Ľ�ɫ�б�
    public List<Character> characters;
    //������Ϸ�ǳ����ҷ��Ľ�ɫ�б�
    public List<Character> players;
    //������Ϸ�ǳ��ĵз��Ľ�ɫ�б�
    public List<Character> enemies;

    //�ж�˳�򣬴����ɫ�ٶ�˳����б�
    public List<Character> speedOrder;

    //�ж����ƾ����ķ�������ɫʹ�ô˷�����ѡ��Ŀ�����ӵ���Ӧ�ٶȵ��ж�����
    public void AddAction()
    {

    }


    //�л�ս���׶η���
    public void ChangeStep(BattleStep type)
    {
        switch (type)
        {
            case BattleStep.None:
                break;
            case BattleStep.Init:
                fightunit = new FightInit();

                break; 
            case BattleStep.Speed:
                fightunit = new SpeedPhase();
                break;
            case BattleStep.Win:
                fightunit = new FightWin();
                break;
            case BattleStep.Lose:
                fightunit = new FightLose();
                break;
            case BattleStep.Selecting:
                fightunit = new SelectingPhase();
                break;        
        }
        fightunit.Init();
    }

    private void Update()
    {
        if (fightunit != null) 
        {
            fightunit.OnUpdate();
        }

    }

    //���ƱȽϷ���
    public void CardCompare(Card card1, Card card2, Character char1, Character char2)
    {
        int value1 = Random.Range(card1.CardMinValue, card1.CardMaxValue);
        int value2 = Random.Range(card2.CardMinValue, card2.CardMaxValue);

        if (card1.CardType == CardType.Attack)
        {
            if (card2.CardType == CardType.Attack)
            {
                if (value1 > value2)
                {
                    char2.CurrentHP -= value1;
                    return;
                }
                else if (value1 == value2)
                {
                    return;
                }
                else if (value1 < value2)
                {
                    char1.CurrentHP -= value2;
                    return;
                }
                return;
            }
            else if (card2.CardType == CardType.Defense)
            {
                if (value1 > value2)
                {
                    char2.CurrentHP -= (value1 - value2);
                    return;
                }
                else if (value1 < value2)
                {
                    char1.EquipOrikey.CurrentSynrate -= value2;
                    return;
                }
                else if (value1 == value2)
                {
                    return;
                }
                return;
            }
            else if (card2.CardType == CardType.Evade)
            {
                if (value1 > value2)
                {
                    char2.CurrentHP -= value1;
                    return;
                }
                else if (value1 < value2)
                {
                    char2.CurrentTurnDice += 1;
                    return;
                }
                else if (value1 == value2)
                {
                    return;
                }
                return;
            }
        }


        else if (card1.CardType == CardType.Defense)
        {
            if (card2.CardType == CardType.Attack)
            {
                if (value2 > value1)
                {
                    char1.CurrentHP -= (value2 - value1);
                    return;
                }
                else if (value2 < value1)
                {
                    char2.EquipOrikey.CurrentSynrate -= value1;
                    return;
                }
                else if (value2 == value1)
                {
                    return;
                }
                return;
            }
            else if (card2.CardType == CardType.Defense)
            {
                if (value1 > value2)
                {
                    char2.EquipOrikey.CurrentSynrate -= (value1 - value2);
                    return;
                }
                else if (value1 < value2)
                {
                    char1.EquipOrikey.CurrentSynrate -= (value2 - value1);
                    return;
                }
                else if (value1 == value2)
                {
                    return;
                }
                return;
            }
            else if (card2.CardType == CardType.Evade)
            {
                if (value1 > value2)
                {
                    char2.EquipOrikey.CurrentSynrate -= value1;
                    return;
                }
                else if (value1 < value2)
                {
                    char2.CurrentTurnDice += 1;
                    return;
                }
                else if (value1 == value2)
                {
                    return;
                }
                return;
            }
        }
        else if (card1.CardType == CardType.Evade)
        {
            if (card2.CardType == CardType.Attack)
            {
                if (value1 > value2)
                {
                    char1.CurrentTurnDice += 1;
                    return;
                }
                else if (value1 < value2)
                {
                    char1.CurrentHP -= value2;
                    return;
                }
                else if (value1 == value2)
                {
                    return;
                }
                return;
            }
            else if (card2.CardType == CardType.Defense)
            {
                if (value1 > value2)
                {
                    char1.CurrentTurnDice += 1;
                    return;
                }
                else if (value1 < value2)
                {
                    char1.EquipOrikey.CurrentSynrate -= value2;
                    return;
                }
                else if (value1 == value2)
                {
                    return;
                }
                return;
            }
            else if (card2.CardType == CardType.Evade)
            {
                if (value1 > value2)
                {
                    char1.CurrentTurnDice += 1;
                    return;
                }
                else if (value1 < value2)
                {
                    char2.CurrentTurnDice += 1;
                    return;
                }
                else if (value1 == value2)
                {
                    return;
                }
                return;
            }
        }
    }



}