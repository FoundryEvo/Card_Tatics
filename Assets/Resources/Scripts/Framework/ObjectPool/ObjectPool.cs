using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//抽屉
public class PoolData
{
    //代表抽屉的父节点
    public GameObject ParentObj;
    //存储每种对象的容器
    public List<GameObject> poolList;

    //构造函数
    public PoolData(GameObject obj, GameObject poolObj)
    {
        //创建一个父对象
        ParentObj = new GameObject(obj.name);
        //把抽屉设为根节点的子物体
        ParentObj.transform.parent = poolObj.transform;
        //设为抽屉的子物体
        poolList = new List<GameObject>() { };
        SortObj(obj);
    }

    //往抽屉里放东西
    public void SortObj(GameObject obj)
    {
        //失活 让其隐藏
        obj.SetActive(false);
        //存起来
        poolList.Add(obj);
        //设置父对象
        obj.transform.parent = ParentObj.transform;
    }

    //从抽屉里拿东西
    public GameObject GetObj()
    {
        GameObject obj = null;
        //取出第一个用
        obj = poolList[0];
        poolList.RemoveAt(0);
        //把拿出来的第一个设为激活
        obj.SetActive(true);
        //然后断开父子关系，放到根目录
        obj.transform.parent = null;
        //返回对象
        return obj;
    }
}



//缓存池模块本体
public class ObjectPool : Singleton<ObjectPool>
{
    //缓存池容器（衣柜）
    private Dictionary<string,PoolData> poolDic = new Dictionary<string, PoolData>();

    private GameObject poolObj;

    //实例化一个对象
    public void Instantiate(string name, UnityAction<GameObject> callback )
    {
        //如果存过，就直接拿来用
        if (poolDic.ContainsKey(name) && poolDic[name].poolList.Count > 0)
        {
            callback(poolDic[name].GetObj());
        }
        else
        {
            ResMgr.Instance().LoadAsync<GameObject>(name, (o) =>
             {
                 o.name = name;
                 callback(o);
             });
        }
    }

    //没用的东西归类的方法
    public void SortObj(string name, GameObject obj)
    {
        if (poolObj == null)
        {
            poolObj = new GameObject("ObejectPool");
        }
        if (poolDic.ContainsKey(name))
        {
            poolDic[name].SortObj(obj);
        }
        else
        {
            poolDic.Add(name, new PoolData(obj, poolObj));
        }
    }

    //清空缓存池,在场景切换时使用
    public void clear()
    {
        poolDic.Clear();
        poolObj = null;
    }

}
