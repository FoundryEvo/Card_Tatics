using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//����
public class PoolData
{
    //�������ĸ��ڵ�
    public GameObject ParentObj;
    //�洢ÿ�ֶ��������
    public List<GameObject> poolList;

    //���캯��
    public PoolData(GameObject obj, GameObject poolObj)
    {
        //����һ��������
        ParentObj = new GameObject(obj.name);
        //�ѳ�����Ϊ���ڵ��������
        ParentObj.transform.parent = poolObj.transform;
        //��Ϊ�����������
        poolList = new List<GameObject>() { };
        SortObj(obj);
    }

    //��������Ŷ���
    public void SortObj(GameObject obj)
    {
        //ʧ�� ��������
        obj.SetActive(false);
        //������
        poolList.Add(obj);
        //���ø�����
        obj.transform.parent = ParentObj.transform;
    }

    //�ӳ������ö���
    public GameObject GetObj()
    {
        GameObject obj = null;
        //ȡ����һ����
        obj = poolList[0];
        poolList.RemoveAt(0);
        //���ó����ĵ�һ����Ϊ����
        obj.SetActive(true);
        //Ȼ��Ͽ����ӹ�ϵ���ŵ���Ŀ¼
        obj.transform.parent = null;
        //���ض���
        return obj;
    }
}



//�����ģ�鱾��
public class ObjectPool : Singleton<ObjectPool>
{
    //������������¹�
    private Dictionary<string,PoolData> poolDic = new Dictionary<string, PoolData>();

    private GameObject poolObj;

    //ʵ����һ������
    public void Instantiate(string name, UnityAction<GameObject> callback )
    {
        //����������ֱ��������
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

    //û�õĶ�������ķ���
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

    //��ջ����,�ڳ����л�ʱʹ��
    public void clear()
    {
        poolDic.Clear();
        poolObj = null;
    }

}
