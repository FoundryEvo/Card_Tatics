using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIBase : MonoBehaviour
{
    //用来储存面板脚本控件的容器
    private Dictionary<string, List<UIBehaviour>> controlDic = new Dictionary<string, List<UIBehaviour>>();
   //当脚本awake时就找到各种控件脚本
    protected virtual void Awake()
    {
        FindChildrenControl<Button>();
        FindChildrenControl<Image>();
        FindChildrenControl<Text>();
        FindChildrenControl<Toggle>();
        FindChildrenControl<Slider>();
        FindChildrenControl<ScrollRect>();
        FindChildrenControl<InputField>();
        FindChildrenControl<TMP_Text>();
    }
    /// <summary>
    /// 得到对应名字对象的对应控件脚本
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="controlName">对象名称</param>
    /// <returns></returns>
    protected T GetControl<T>(string controlName) where T : UIBehaviour
    {
        if (controlDic.ContainsKey(controlName))
        {
            for (int i = 0; i < controlDic[controlName].Count; ++i)
            {
                if (controlDic[controlName][i] is T)
                    return controlDic[controlName][i] as T;
            }
        }
        return null;
    }

    //显示面板
    public virtual void ShowMe(){}
    //隐藏面板
    public virtual void HideMe(){}

    public virtual void Init(){}


    //Toggle的虚方法
    protected  virtual void OnValueChanged(string objName, bool value){}
    //button的虚方法
    protected virtual void OnClick(string objName){}


    //找到子对象所有的控件脚本
    private void FindChildrenControl<T>() where T : UIBehaviour
    {
        //声明一个泛型数组用来存储找到的控件脚本
        T[] controls = this.GetComponentsInChildren<T>();
        for (int i = 0; i < controls.Length; i++)
        {
            //获得每个控件脚本依附的对象名
            string objName = controls[i].gameObject.name;

            if (controlDic.ContainsKey(objName))
            {
                //如果存在该对象，就加进对应的UI列表内
                controlDic[objName].Add(controls[i]);
            }
            else
            {
                //如果不存在，就新建一个键值对
                controlDic.Add(objName, new List<UIBehaviour>() { controls[i] } );
            }
            //如果同时是按钮控件
            if (controls[i] is Button)
            {
                (controls[i] as Button).onClick.AddListener(() =>
                {
                    OnClick(objName);
                });
            }
            //如果是单选框或者多选框
            else if (controls[i] is Toggle)
            {
                (controls[i] as Toggle).onValueChanged.AddListener((value) =>
                {
                    OnValueChanged(objName, value);
                });
            }
            //如果是还有其他，回头在这里写
        }        

    }

}
