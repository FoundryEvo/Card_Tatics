using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResMgr : Singleton<ResMgr>
{
    //同步加载资源
    public T Load<T>(string name) where T : Object
    {
        //如果对象是一个GameObject类型的 我把他实例化后 再返回出去 外部 直接使用即可
        T res = Resources.Load<T>(name);
        if (res is GameObject)
            return GameObject.Instantiate(res);
        else //TextAsset AudioClip
            return res;
    }

    //异步加载资源
    public void LoadAsync<T>(string name,UnityAction<T> callback) where T : Object
    {
        //开启异步加载的协程
        MonoMgr.Instance().StartCoroutine(RealLoadAsync(name,callback));
    }


    //public async Task<T> LoadAsync2<T>(string name, UnityAction<T> callback) where T : Object
    //{
    //    var tcs = new TaskCompletionSource<T>();
    //    MonoMgr.Instance().StartCoroutine(RealLoadAsync<T>(name, (res) =>
    //    {
    //        //异步操作结束后，设置TaskCompletionSource的结果，并标记为已完成
    //        tcs.SetResult(res);
    //    }));

    //    //等待TaskCompletionSource的任务完成
    //    return await tcs.Task;
    //}

    //真正起作用的协程函数
    private IEnumerator RealLoadAsync<T>(string name, UnityAction<T> callback) where T: Object
    {
        Debug.Log(name);
        ResourceRequest r = Resources.LoadAsync<T>(name);
        Debug.Log("异步返回值");
        yield return r;
        Debug.Log("异步加载完成后");

        //加载结束之后需要执行的逻辑
        if (r.asset is GameObject)
        {
            Debug.Log("gameobject实例化");
            callback(GameObject.Instantiate(r.asset) as T);
        }
        else
        {
            Debug.Log("不是gameobject");
            callback(r.asset as T);
        }
    }
}
