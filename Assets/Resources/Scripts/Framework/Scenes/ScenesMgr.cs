using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScenesMgr : Singleton<ScenesMgr>
{
    //ͬ�����س���
    public void LoadScean(string name, UnityAction task)
    {
        SceneManager.LoadScene(name);
        //������ɹ��� �Ż�ȥִ��task
        task();
    }

    //�첽���س���
    public void LoadSceanAsync(string name, UnityAction task)
    {
        //����������Э�̺���
        MonoMgr.Instance().StartCoroutine(RealLoadSceanAsync(name,task));
    }

    //Э���첽���س���
    private IEnumerator RealLoadSceanAsync(string name, UnityAction task)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);

        while (!ao.isDone)
        {
            //���ⲿ���¼�����ʱ��������Զ��������м����¼�
            EventCenter.Instance().EventTrigger("����������", ao.progress);
            yield return ao.progress;
        }
        //������ɺ�ִ��ί��
        task();
    }
}
