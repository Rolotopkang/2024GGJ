using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_TestLittle1 : EventBase
{
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("1触发了");
    }
}
