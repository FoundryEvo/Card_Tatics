using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMgr : Singleton<CharacterMgr>
{
    //角色管理器，用于管理角色的装备，卡牌，玩家拥有的角色，游戏的角色编队。同时用于角色信息的保存。

    //角色库
    public Dictionary<string, Character> characterLibrary; 

    //玩家角色编队
    public List<Character> players;

    //敌人图鉴
    public Dictionary<string, Character> enemyLibrary;

    //关卡敌人编队
    public List<Character> enemies;

    //保存角色的方法


}
