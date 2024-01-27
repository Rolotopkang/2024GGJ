using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_TestLittle4 : EventBase
{
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("4触发了");
    }
}
