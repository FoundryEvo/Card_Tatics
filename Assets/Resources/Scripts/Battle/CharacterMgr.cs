using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMgr : Singleton<CharacterMgr>
{
    //��ɫ�����������ڹ����ɫ��װ�������ƣ����ӵ�еĽ�ɫ����Ϸ�Ľ�ɫ��ӡ�ͬʱ���ڽ�ɫ��Ϣ�ı��档

    //��ɫ��
    public Dictionary<string, Character> characterLibrary; 

    //��ҽ�ɫ���
    public List<Character> players;

    //����ͼ��
    public Dictionary<string, Character> enemyLibrary;

    //�ؿ����˱��
    public List<Character> enemies;

    //�����ɫ�ķ���


}
