using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPhase : FightUnit
{

    public override void Init()
    {
        base.Init();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    //�ٶȾ����������������־���ÿ���˵��ٶ�˳��

    public List<Character> DetermineSpeed(List<Character> character)
    {
        character.Sort((a, b) => b.CurrentSpeed.CompareTo(a.CurrentSpeed)); //�Ӵ�С����

        BattleMgr.Instance().speedOrder = character;

        return character;  //��������Ľ�ɫ�б�
    }



}
