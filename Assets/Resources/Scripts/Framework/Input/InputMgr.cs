using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : Singleton<InputMgr>
{
    //���ڿ�����ر��Զ���������ı���
    private bool isStart = false;

    //���캯����һ��ʼ����������¼�����
    public InputMgr()
    {
        MonoMgr.Instance().AddUpdateListener(MyUpdate);
    }

    /// <summary>
    /// �Ƿ�����ر� �ҵ�������
    /// </summary>
    public void EnableCheck(bool isOpen)
    {
        isStart = isOpen;
    }


    /// <summary>
    /// ������ⰴ��̧���� �ַ��¼���
    /// </summary>
    /// <param name="key">���µļ�</param>
    private void CheckKeyCode(KeyCode key)
    {
        //�¼�����ģ�� �ַ���λ�����¼�
        if (Input.GetKeyDown(key))
            EventCenter.Instance().EventTrigger("KeyDown", key);
        //�¼�����ģ�� �ַ���λ̧���¼�
        if (Input.GetKeyUp(key))
            EventCenter.Instance().EventTrigger("KeyUp", key);
        //�¼�����ģ�� �ַ�������ס�¼�
        if (Input.GetKey(key))
            EventCenter.Instance().EventTrigger("Key", key);
    }

    private void CheckMouseKey(int mouse)
    {
        if (Input.GetMouseButtonDown(mouse))
            EventCenter.Instance().EventTrigger("MouseDown", mouse);
        if (Input.GetMouseButtonUp(mouse))
            EventCenter.Instance().EventTrigger("MouseUp", mouse);
        if (Input.GetMouseButton(mouse))
            EventCenter.Instance().EventTrigger("Mouse", mouse);

    }
    private void MyUpdate()
    {
        //û�п��������� �Ͳ�ȥ��� ֱ��return
        if (!isStart)
            return;

        CheckKeyCode(KeyCode.W);
        CheckKeyCode(KeyCode.S);
        CheckKeyCode(KeyCode.A);
        CheckKeyCode(KeyCode.D);
        CheckKeyCode(KeyCode.Space);
        CheckKeyCode(KeyCode.Escape);
        CheckKeyCode(KeyCode.LeftControl);
        CheckKeyCode(KeyCode.Return);
        CheckKeyCode(KeyCode.P);
        CheckKeyCode(KeyCode.M);
        CheckKeyCode(KeyCode.B);
        CheckKeyCode(KeyCode.F);
        CheckKeyCode(KeyCode.E);
        CheckKeyCode(KeyCode.C);
        CheckKeyCode(KeyCode.Alpha1);
        CheckKeyCode(KeyCode.Alpha2);
        CheckKeyCode(KeyCode.Alpha3);
        CheckKeyCode(KeyCode.Alpha4);
        CheckKeyCode(KeyCode.UpArrow);
        CheckKeyCode(KeyCode.LeftArrow);
        CheckKeyCode(KeyCode.RightArrow);
        CheckKeyCode(KeyCode.DownArrow);
        CheckKeyCode(KeyCode.I);
        CheckMouseKey(0);
        CheckMouseKey(1);
    }
}
