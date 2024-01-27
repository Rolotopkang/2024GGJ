using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.Video;

/// <summary>
/// 事件抽象基类
/// </summary>
[Serializable]
public class EventBase : MonoBehaviour
{
    public EventSO eventSo;
    public bool isBigEvent => eventSo.IsBigEvent;
    public delegate OnEventCanceled;


    /// <summary>
    /// (每个回合结算前)触发事件
    /// </summary>
    public virtual void TriggerEvent(){}

    /// <summary>
    /// 当事件结束时
    /// </summary>
    public virtual void  EventCancel(){}
}
