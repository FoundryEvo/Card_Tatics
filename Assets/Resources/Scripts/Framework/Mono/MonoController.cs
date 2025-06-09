using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoController : MonoBehaviour
{
    private event UnityAction updateEvent;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (updateEvent != null)
            updateEvent();
    }

    /// <summary>
    /// ���ⲿ�ṩ�� ���֡�����¼��ĺ���
    /// </summary>
    /// <param name="update"></param>
    public void AddUpdateListener(UnityAction update)
    {
        updateEvent += update;
    }

    /// <summary>
    /// �ṩ���ⲿ �����Ƴ�֡�����¼�����
    /// </summary>
    /// <param name="update"></param>
    public void RemoveUpdateListener(UnityAction update)
    {
        updateEvent -= update;
    }
}
