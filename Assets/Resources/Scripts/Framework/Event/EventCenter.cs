using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ICustomEvent
{
    //����һ���սӿ�������������ί��
}

public class CustomEvent<T> : ICustomEvent
{ //���Ͱ���ί��
    public UnityAction<T> actions;
    public CustomEvent(UnityAction<T> action)
    {
        actions += action;
    }
}
public class CustomEvent : ICustomEvent
{//�Ƿ��Ͱ���
    public UnityAction actions;
    public CustomEvent(UnityAction action)
    {
        actions += action;
    }

}


//�Զ����¼�����,�̳е���ģʽģ����
public class EventCenter : Singleton<EventCenter>
{
    //����һ��˽�дʵ����������洢ʵ��,ί��ʹ�������滻ԭ����а�����ʹ���ܹ����ݷ��Ͳ���������
    private Dictionary<string, ICustomEvent> eventDic = new Dictionary<string, ICustomEvent>();

    /// <summary>
    /// ��ӷ����¼�
    /// </summary>
    /// <param name="name">�¼���</param>
    /// <param name="action">��Ҫ�����ί���¼�</param>
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
    /// ��ӷǷ����¼�
    /// </summary>
    /// <param name="name">�¼���</param>
    /// <param name="action">��Ҫ�����ί���¼�</param>
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
    /// �Ƴ������¼�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name">�¼���</param>
    /// <param name="action">��Ҫ�Ƴ���ί���¼�</param>
    public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as CustomEvent<T>).actions -= action;
        }       
    }

    /// <summary>
    /// �Ƴ��Ƿ����¼�
    /// </summary>
    /// <param name="name">�¼���</param>
    /// <param name="action">��Ҫ�Ƴ���ί���¼�</param>
    public void RemoveEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as CustomEvent).actions -= action;
        }

    }

    /// <summary>
    /// ���������¼�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name">�¼���</param>
    /// <param name="info">��Ҫ����ί���¼��Ķ���</param>
    public void EventTrigger<T>(string name, T info)
    {   //�ж��Ƿ���ڸ��¼�
        if (eventDic.ContainsKey(name))
        {   //������ڣ��ж�ί���Ƿ�Ϊ�գ������Ϊ���򴥷�
            if ((eventDic[name] as CustomEvent<T>)?.actions != null)
            {   //�������¼�
                (eventDic[name] as CustomEvent<T>).actions.Invoke(info);
            }
        }
    }

    /// <summary>
    /// �����¼�
    /// </summary>
    /// <param name="name">�¼���</param>
    public void EventTrigger(string name)
    {   //�ж��Ƿ���ڸ��¼�
        if (eventDic.ContainsKey(name))
        {   //������ڣ��ж�ί���Ƿ�Ϊ�գ������Ϊ���򴥷�
            if ((eventDic[name] as CustomEvent).actions != null)
            {   //�������¼�
                (eventDic[name] as CustomEvent).actions.Invoke();
            }
        }

    }

    /// <summary>
    /// ����¼�
    /// ��Ҫ���� �����л�ʱ
    /// </summary>
    public void clear()
    {
        eventDic.Clear();
    }

}
