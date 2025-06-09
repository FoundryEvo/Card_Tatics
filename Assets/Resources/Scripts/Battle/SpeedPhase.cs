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

    //速度决定方法，在这里现决定每个人的速度顺序

    public List<Character> DetermineSpeed(List<Character> character)
    {
        character.Sort((a, b) => b.CurrentSpeed.CompareTo(a.CurrentSpeed)); //从大到小排序

        BattleMgr.Instance().speedOrder = character;

        return character;  //输出排序后的角色列表
    }



}
