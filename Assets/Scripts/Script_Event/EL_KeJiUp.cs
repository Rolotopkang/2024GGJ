using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EL_KeJiUp : EventBase
{
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("科技UP触发了");
        GameData.GetInstance().Draw_Card_Available = false;
        GameData.GetInstance().Science_Point_Output_Fix *= 2f;
    }
}
