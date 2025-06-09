using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScenesMgr : Singleton<ScenesMgr>
{
    //同步加载场景
    public void LoadScean(string name, UnityAction task)
    {
        SceneManager.LoadScene(name);
        //加载完成过后 才会去执行task
        task();
    }

    //异步加载场景
    public void LoadSceanAsync(string name, UnityAction task)
    {
        //调用真正的协程函数
        MonoMgr.Instance().StartCoroutine(RealLoadSceanAsync(name,task));
    }

    //协程异步加载场景
    private IEnumerator RealLoadSceanAsync(string name, UnityAction task)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);

        while (!ao.isDone)
        {
            //当外部有事件监听时，这里会自动触发所有监听事件
            EventCenter.Instance().EventTrigger("进度条更新", ao.progress);
            yield return ao.progress;
        }
        //加载完成后，执行委托
        task();
    }
}
