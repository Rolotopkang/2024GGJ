using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EL_LiangCang : EventBase
{
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("粮仓触发了");
        GameData.GetInstance().Supplies_Output_Fix *= 1.5f;
    }
}
