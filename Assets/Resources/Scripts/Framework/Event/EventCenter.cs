using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ICustomEvent
{
    //声明一个空接口用来包裹泛型委托
}

public class CustomEvent<T> : ICustomEvent
{ //泛型包裹委托
    public UnityAction<T> actions;
    public CustomEvent(UnityAction<T> action)
    {
        actions += action;
    }
}
public class CustomEvent : ICustomEvent
{//非泛型包裹
    public UnityAction actions;
    public CustomEvent(UnityAction action)
    {
        actions += action;
    }

}


//自定义事件中心,继承单例模式模板类
public class EventCenter : Singleton<EventCenter>
{
    //声明一个私有词典容器用来存储实践,委托使用里氏替换原则进行包裹，使其能够传递泛型参数不报错
    private Dictionary<string, ICustomEvent> eventDic = new Dictionary<string, ICustomEvent>();

    /// <summary>
    /// 添加泛型事件
    /// </summary>
    /// <param name="name">事件名</param>
    /// <param name="action">需要处理的委托事件</param>
    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as CustomEvent<T>).actions += action;
        }
        else
        {
            eventDic.Add(name, new CustomEvent<T>(action));
        }
              
    }
    /// <summary>
    /// 添加非泛型事件
    /// </summary>
    /// <param name="name">事件名</param>
    /// <param name="action">需要处理的委托事件</param>
    public void AddEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as CustomEvent).actions += action;
        }
        else 
        {
            eventDic.Add(name, new CustomEvent(action));
        }
    }

    /// <summary>
    /// 移除泛型事件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name">事件名</param>
    /// <param name="action">需要移除的委托事件</param>
    public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as CustomEvent<T>).actions -= action;
        }       
    }

    /// <summary>
    /// 移除非泛型事件
    /// </summary>
    /// <param name="name">事件名</param>
    /// <param name="action">需要移除的委托事件</param>
    public void RemoveEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as CustomEvent).actions -= action;
        }

    }

    /// <summary>
    /// 触发泛型事件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name">事件名</param>
    /// <param name="info">需要触发委托事件的对象</param>
    public void EventTrigger<T>(string name, T info)
    {   //判断是否存在该事件
        if (eventDic.ContainsKey(name))
        {   //如果存在，判断委托是否为空，如果不为空则触发
            if ((eventDic[name] as CustomEvent<T>)?.actions != null)
            {   //触发该事件
                (eventDic[name] as CustomEvent<T>).actions.Invoke(info);
            }
        }
    }

    /// <summary>
    /// 触发事件
    /// </summary>
    /// <param name="name">事件名</param>
    public void EventTrigger(string name)
    {   //判断是否存在该事件
        if (eventDic.ContainsKey(name))
        {   //如果存在，判断委托是否为空，如果不为空则触发
            if ((eventDic[name] as CustomEvent).actions != null)
            {   //触发该事件
                (eventDic[name] as CustomEvent).actions.Invoke();
            }
        }

    }

    /// <summary>
    /// 清空事件
    /// 主要用在 场景切换时
    /// </summary>
    public void clear()
    {
        eventDic.Clear();
    }

}
