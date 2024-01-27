using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EL_QiHuo : EventBase
{
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("期货触发了");
        GameData.GetInstance().Money_Output_Fix *= 0.5f;
        GameData.GetInstance().Supplies_Output_Fix *= 2f;
    }
}
