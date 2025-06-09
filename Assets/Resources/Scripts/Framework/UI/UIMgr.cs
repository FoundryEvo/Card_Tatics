using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
//using DG.Tweening;
using UnityEngine.UI;

/// <summary>
/// 自定义的UI层级
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
    //声明用来存储UI面板的词典容器
    public Dictionary<string, UIBase> panelDic = new Dictionary<string, UIBase>();

    //声明出各个UI层级
    private Transform btm;
    private Transform mid;
    private Transform top;
    private Transform system;

    //记录我们UI的Canvas父对象 方便以后外部可能会使用它
    public RectTransform canvas;

    //无参构造函数，用来保证画布的唯一性和其他功能
    public UIMgr()
    {
        //加载并创建Canvas
        GameObject obj = ResMgr.Instance().Load<GameObject>("UI/Canvas");
        //记录，保证唯一性
        canvas = obj.transform as RectTransform;
        //让其过场景的时候 不被移除
        GameObject.DontDestroyOnLoad(obj);

        //找到各层
        btm = canvas.Find("Btm");
        mid = canvas.Find("Mid");
        top = canvas.Find("Top");
        system = canvas.Find("System");

        //加载并创建EventSystem，obj的内容已经在上方赋值给了convas
        obj = ResMgr.Instance().Load<GameObject>("UI/EventSystem");
        //让其过场景的时候 不被移除
        GameObject.DontDestroyOnLoad(obj);
    }
    /// <summary>
    /// 通过层级枚举 得到对应层级的父对象
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
    /// 显示面板
    /// </summary>
    /// <typeparam name="T">面板脚本类型</typeparam>
    /// <param name="panelName">面板名</param>
    /// <param name="layer">显示在哪一层</param>
    /// <param name="callBack">当面板预设体创建成功后 你想做的事</param>
    public void ShowPanel<T>(string panelName, E_UI_Layer layer = E_UI_Layer.Mid, UnityAction<T> callBack = null) where T : UIBase
    {   //如果有，就显示
        if (panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].ShowMe();
            if (callBack != null)
                callBack(panelDic[panelName] as T);
            //避免面板重复加载 如果存在该面板 即直接显示 调用回调函数后  直接return 不再处理后面的异步加载逻辑
            return;
        }
        //如果没有就异步加载、添加，然后显示
        ResMgr.Instance().LoadAsync<GameObject>("UI/" + panelName, (obj) =>
          {
              //把他作为 Canvas的子对象
              //并且 要设置它的相对位置
              //找到父对象 你到底显示在哪一层
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
              //然后设置父对象 
              obj.transform.SetParent(parent,false);
              //设置位置和大小
              obj.transform.localPosition = Vector3.zero;
              obj.transform.localScale = Vector3.one;
              //设置锚点位置
              (obj.transform as RectTransform).offsetMax = Vector2.zero;
              (obj.transform as RectTransform).offsetMin = Vector2.zero;

              //得到预设体身上的面板脚本
              T panel = obj.GetComponent<T>();
              // 处理面板创建完成后的逻辑
              if (callBack != null)
                  callBack(panel);

              panel.ShowMe();

              //把面板存起来
              panelDic.Add(panelName, panel);

          });

    }

    //隐藏面板
    public void ClosePanel<T>(string panelName)
    {
        //如果有这个面板，就先隐藏，再删掉，最后从字典里移出去
        if (panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].HideMe();
            GameObject.Destroy(panelDic[panelName].gameObject);
            panelDic.Remove(panelName);
        }
        //没有就什么都不用做
    }

    /// <summary>
    /// 得到某一个已经显示的面板 方便外部使用
    /// </summary>
    /// <typeparam name="T">面板类型</typeparam>
    /// <param name="name">面板名</param>
    /// <returns></returns>
    /// 得到面板
    public T GetPanel<T>(string panelName) where T : UIBase
    {
        //有就返回出去
        if(panelDic.ContainsKey(panelName))
            return panelDic[panelName] as T;
        //没有就返回null
        return null;
    }

    /// <summary>
    /// 给控件添加自定义事件监听
    /// </summary>
    /// <param name="control">控件对象</param>
    /// <param name="type">事件类型</param>
    /// <param name="callBack">事件的响应函数,就是要做什么</param>
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

    //创建血条
    public void CreateHpBar(GameObject parent)
    {
        
        ObjectPool.Instance().Instantiate("UI/Battle/HP", (HP)=>
        {
            GameObject obj = HP;
            obj.transform.SetParent(parent.transform, true);
            obj.transform.SetAsLastSibling();
        });
    }

    //提示界面
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
