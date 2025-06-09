using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> where T:new()
{
    //私有成员变量
    private static T instance;

    //供外部使用的公共成员属性
    public static T Instance()
    {
        if (instance == null)
        {
            instance = new T();
        }
        return instance;
    }
}
