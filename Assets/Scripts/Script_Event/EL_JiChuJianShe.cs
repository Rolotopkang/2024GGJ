using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EL_JiChuJianShe : EventBase
{
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("基础建设触发了");
        GameData.GetInstance().Science_Point_Output_Fix *= 1.5f;
    }
}
