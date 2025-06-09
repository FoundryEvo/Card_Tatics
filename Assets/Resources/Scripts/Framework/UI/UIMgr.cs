using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
//using DG.Tweening;
using UnityEngine.UI;

/// <summary>
/// �Զ����UI�㼶
/// </summary>
public enum E_UI_Layer
{
    Top,
    Mid,
    Bottom,
    System,
}

public class UIMgr : Singleton<UIMgr>
{
    //���������洢UI���Ĵʵ�����
    public Dictionary<string, UIBase> panelDic = new Dictionary<string, UIBase>();

    //����������UI�㼶
    private Transform btm;
    private Transform mid;
    private Transform top;
    private Transform system;

    //��¼����UI��Canvas������ �����Ժ��ⲿ���ܻ�ʹ����
    public RectTransform canvas;

    //�޲ι��캯����������֤������Ψһ�Ժ���������
    public UIMgr()
    {
        //���ز�����Canvas
        GameObject obj = ResMgr.Instance().Load<GameObject>("UI/Canvas");
        //��¼����֤Ψһ��
        canvas = obj.transform as RectTransform;
        //�����������ʱ�� �����Ƴ�
        GameObject.DontDestroyOnLoad(obj);

        //�ҵ�����
        btm = canvas.Find("Btm");
        mid = canvas.Find("Mid");
        top = canvas.Find("Top");
        system = canvas.Find("System");

        //���ز�����EventSystem��obj�������Ѿ����Ϸ���ֵ����convas
        obj = ResMgr.Instance().Load<GameObject>("UI/EventSystem");
        //�����������ʱ�� �����Ƴ�
        GameObject.DontDestroyOnLoad(obj);
    }
    /// <summary>
    /// ͨ���㼶ö�� �õ���Ӧ�㼶�ĸ�����
    /// </summary>
    /// <param name="layer"></param>
    /// <returns></returns>
    public Transform GetLayerParent(E_UI_Layer layer)
    {
        switch (layer)
        {
            case E_UI_Layer.Bottom:
                return this.btm;
            case E_UI_Layer.Mid:
                return this.mid;
            case E_UI_Layer.Top:
                return this.top;
            case E_UI_Layer.System:
                return this.system;
        }
        return null;
    }

    /// <summary>
    /// ��ʾ���
    /// </summary>
    /// <typeparam name="T">���ű�����</typeparam>
    /// <param name="panelName">�����</param>
    /// <param name="layer">��ʾ����һ��</param>
    /// <param name="callBack">�����Ԥ���崴���ɹ��� ����������</param>
    public void ShowPanel<T>(string panelName, E_UI_Layer layer = E_UI_Layer.Mid, UnityAction<T> callBack = null) where T : UIBase
    {   //����У�����ʾ
        if (panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].ShowMe();
            if (callBack != null)
                callBack(panelDic[panelName] as T);
            //��������ظ����� ������ڸ���� ��ֱ����ʾ ���ûص�������  ֱ��return ���ٴ��������첽�����߼�
            return;
        }
        //���û�о��첽���ء���ӣ�Ȼ����ʾ
        ResMgr.Instance().LoadAsync<GameObject>("UI/" + panelName, (obj) =>
          {
              //������Ϊ Canvas���Ӷ���
              //���� Ҫ�����������λ��
              //�ҵ������� �㵽����ʾ����һ��
              Transform parent = btm;
              switch (layer)    
              {
                  case E_UI_Layer.Bottom:
                      parent = btm;
                      break;
                  case E_UI_Layer.Mid:
                      parent = mid;
                      break;
                  case E_UI_Layer.Top:
                      parent = top;
                      break;
                  case E_UI_Layer.System:
                      parent = system;
                      break;
              }
              // T res = GameObject.Instantiate(obj) as T;
              //Ȼ�����ø����� 
              obj.transform.SetParent(parent,false);
              //����λ�úʹ�С
              obj.transform.localPosition = Vector3.zero;
              obj.transform.localScale = Vector3.one;
              //����ê��λ��
              (obj.transform as RectTransform).offsetMax = Vector2.zero;
              (obj.transform as RectTransform).offsetMin = Vector2.zero;

              //�õ�Ԥ�������ϵ����ű�
              T panel = obj.GetComponent<T>();
              // ������崴����ɺ���߼�
              if (callBack != null)
                  callBack(panel);

              panel.ShowMe();

              //����������
              panelDic.Add(panelName, panel);

          });

    }

    //�������
    public void ClosePanel<T>(string panelName)
    {
        //����������壬�������أ���ɾ���������ֵ����Ƴ�ȥ
        if (panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].HideMe();
            GameObject.Destroy(panelDic[panelName].gameObject);
            panelDic.Remove(panelName);
        }
        //û�о�ʲô��������
    }

    /// <summary>
    /// �õ�ĳһ���Ѿ���ʾ����� �����ⲿʹ��
    /// </summary>
    /// <typeparam name="T">�������</typeparam>
    /// <param name="name">�����</param>
    /// <returns></returns>
    /// �õ����
    public T GetPanel<T>(string panelName) where T : UIBase
    {
        //�оͷ��س�ȥ
        if(panelDic.ContainsKey(panelName))
            return panelDic[panelName] as T;
        //û�оͷ���null
        return null;
    }

    /// <summary>
    /// ���ؼ�����Զ����¼�����
    /// </summary>
    /// <param name="control">�ؼ�����</param>
    /// <param name="type">�¼�����</param>
    /// <param name="callBack">�¼�����Ӧ����,����Ҫ��ʲô</param>
    public static void AddCustomEventListener(UIBehaviour control, EventTriggerType type, UnityAction<BaseEventData> callBack)
    {
        EventTrigger trigger = control.GetComponent<EventTrigger>();
        if (trigger == null)
            trigger = control.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.AddListener(callBack);

        trigger.triggers.Add(entry);
    }

    //����Ѫ��
    public void CreateHpBar(GameObject parent)
    {
        
        ObjectPool.Instance().Instantiate("UI/Battle/HP", (HP)=>
        {
            GameObject obj = HP;
            obj.transform.SetParent(parent.transform, true);
            obj.transform.SetAsLastSibling();
        });
    }

    //��ʾ����
    //public void ShowTip(string msg, Color color, System.Action callback = null)
    //{
    //    GameObject obj = ResMgr.Instance().Load<GameObject>("UI/Tips");
    //    Text text = obj.transform.Find("bg/Text").GetComponent<Text>();
    //    text.color = color;
    //    text.text = msg;
    //    Tween scale1 = obj.transform.Find("bg").DOScale(1,0.4f);
    //    Tween scale2 = obj.transform.Find("bg").DOScale(0, 0.4f);

    //    Sequence seq = DOTween.Sequence();
    //    seq.Append(scale1);
    //    seq.AppendInterval(0.5f);
    //    seq.Append(scale2);
    //    seq.AppendCallback(delegate ()
    //    { 
    //        if (callback != null)
    //        {
    //            callback();
    //        }
    //    });
    //    MonoBehaviour.Destroy(obj, 1);

    //}
}
