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

    //������ҽ��еı���Լ���Ϸ�ؿ��ĵ���,���ɳ�ʼ�Ľ�ɫ�б�
    public void CreateCharacterList(List<Character> players, List<Character> enemies)
    {
        BattleMgr.Instance().characters.Clear(); //ÿ�ν���ؿ�ʱ�����һ�ν�ɫ�б�
        BattleMgr.Instance().characters.AddRange(players);
        BattleMgr.Instance().characters.AddRange(enemies);
    }
    public void CreateCharacterList()
    {
        CreateCharacterList(BattleMgr.Instance().players, BattleMgr.Instance().enemies);
    }

}
