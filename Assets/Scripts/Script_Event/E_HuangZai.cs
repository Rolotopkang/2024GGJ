
using System;
using UnityEngine;

[Serializable]
public class E_HuangZai : EventBase
{
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("蝗灾触发了");
    }
}