using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> where T:new()
{
    //˽�г�Ա����
    private static T instance;

    //���ⲿʹ�õĹ�����Ա����
    public static T Instance()
    {
        if (instance == null)
        {
            instance = new T();
        }
        return instance;
    }
}
