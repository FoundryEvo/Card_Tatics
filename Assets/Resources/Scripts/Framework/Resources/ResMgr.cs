using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResMgr : Singleton<ResMgr>
{
    //ͬ��������Դ
    public T Load<T>(string name) where T : Object
    {
        //���������һ��GameObject���͵� �Ұ���ʵ������ �ٷ��س�ȥ �ⲿ ֱ��ʹ�ü���
        T res = Resources.Load<T>(name);
        if (res is GameObject)
            return GameObject.Instantiate(res);
        else //TextAsset AudioClip
            return res;
    }

    //�첽������Դ
    public void LoadAsync<T>(string name,UnityAction<T> callback) where T : Object
    {
        //�����첽���ص�Э��
        MonoMgr.Instance().StartCoroutine(RealLoadAsync(name,callback));
    }


    //public async Task<T> LoadAsync2<T>(string name, UnityAction<T> callback) where T : Object
    //{
    //    var tcs = new TaskCompletionSource<T>();
    //    MonoMgr.Instance().StartCoroutine(RealLoadAsync<T>(name, (res) =>
    //    {
    //        //�첽��������������TaskCompletionSource�Ľ���������Ϊ�����
    //        tcs.SetResult(res);
    //    }));

    //    //�ȴ�TaskCompletionSource���������
    //    return await tcs.Task;
    //}

    //���������õ�Э�̺���
    private IEnumerator RealLoadAsync<T>(string name, UnityAction<T> callback) where T: Object
    {
        Debug.Log(name);
        ResourceRequest r = Resources.LoadAsync<T>(name);
        Debug.Log("�첽����ֵ");
        yield return r;
        Debug.Log("�첽������ɺ�");

        //���ؽ���֮����Ҫִ�е��߼�
        if (r.asset is GameObject)
        {
            Debug.Log("gameobjectʵ����");
            callback(GameObject.Instantiate(r.asset) as T);
        }
        else
        {
            Debug.Log("����gameobject");
            callback(r.asset as T);
        }
    }
}
