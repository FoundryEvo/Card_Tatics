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
    //战斗单元
    public FightUnit fightunit;

    //本局游戏登场的敌我双方的角色列表
    public List<Character> characters;
    //本局游戏登场的我方的角色列表
    public List<Character> players;
    //本局游戏登场的敌方的角色列表
    public List<Character> enemies;

    //行动顺序，储存角色速度顺序的列表
    public List<Character> speedOrder;

    //行动卡牌决定的方法，角色使用此方法将选择的卡牌添加到对应速度的行动堆中
    public void AddAction()
    {

    }


    //切换战斗阶段方法
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

    //卡牌比较方法
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