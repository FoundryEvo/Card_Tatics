using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightInit : FightUnit
{
    public override void Init()
    {
        base.Init();
        CreateCharacterList();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    //根据玩家进行的编队以及游戏关卡的敌人,生成初始的角色列表
    public void CreateCharacterList(List<Character> players, List<Character> enemies)
    {
        BattleMgr.Instance().characters.Clear(); //每次进入关卡时，清空一次角色列表
        BattleMgr.Instance().characters.AddRange(players);
        BattleMgr.Instance().characters.AddRange(enemies);
    }
    public void CreateCharacterList()
    {
        CreateCharacterList(BattleMgr.Instance().players, BattleMgr.Instance().enemies);
    }

}
