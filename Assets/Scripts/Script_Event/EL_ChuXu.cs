using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EL_ChuXu: EventBase
{
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("储蓄触发了");
        GameData.GetInstance().Money_Output_Fix *= 1.5f;
    }
}
