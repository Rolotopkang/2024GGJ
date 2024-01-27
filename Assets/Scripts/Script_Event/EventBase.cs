using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.Video;

/// <summary>
/// 事件抽象基类
/// </summary>
[Serializable]
public class EventBase : MonoBehaviour
{
    public EventSO eventSo;
    public bool isBigEvent => eventSo.IsBigEvent;
    
    public Action OnEventCanceled;

    public bool active;

    public int WaitRound;

    public int LastRound;

    private void Awake()
    {
        OnEventCanceled += EventCancel;
    }

    public void Init()
    {
        WaitRound = eventSo.EventWaitTime;
        LastRound = eventSo.EventLastTime;
        active = false;
    }
    
    /// <summary>
    /// (每个回合结算前)触发事件
    /// </summary>
    public void TriggerEvent()
    {
        if (!active)
        {
            WaitRound--;
            if (WaitRound <= 0)
            {
                active = true;
            }
            return;
        }
        
        //各自逻辑
        Debug.Log(this.name+ "事件结算");
        EventTrigger();

        LastRound--;
        if (LastRound <= 0)
        { 
            OnEventCanceled.Invoke();
        }
        
    }

    protected virtual void EventTrigger()
    {
        
    }

    /// <summary>
    /// 当事件结束时
    /// </summary>
    public virtual void EventCancel()
    {
        GameEventSystem.GetInstance().DelEvent(this);
    }
}
