using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_TestLittle3: EventBase
{
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("3触发了");
    }
}
