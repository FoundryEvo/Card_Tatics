using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : Singleton<InputMgr>
{
    //用于开启或关闭自定义输入检测的变量
    private bool isStart = false;

    //构造函数，一开始就添件更新事件监听
    public InputMgr()
    {
        MonoMgr.Instance().AddUpdateListener(MyUpdate);
    }

    /// <summary>
    /// 是否开启或关闭 我的输入检测
    /// </summary>
    public void EnableCheck(bool isOpen)
    {
        isStart = isOpen;
    }


    /// <summary>
    /// 用来检测按键抬起按下 分发事件的
    /// </summary>
    /// <param name="key">按下的键</param>
    private void CheckKeyCode(KeyCode key)
    {
        //事件中心模块 分发键位按下事件
        if (Input.GetKeyDown(key))
            EventCenter.Instance().EventTrigger("KeyDown", key);
        //事件中心模块 分发键位抬起事件
        if (Input.GetKeyUp(key))
            EventCenter.Instance().EventTrigger("KeyUp", key);
        //事件中心模块 分发持续按住事件
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
        //没有开启输入检测 就不去检测 直接return
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
