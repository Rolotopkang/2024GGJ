using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_TestLittle2 : EventBase
{
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("2触发了");
    }
}
