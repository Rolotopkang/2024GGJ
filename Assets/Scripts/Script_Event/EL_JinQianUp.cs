using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EL_JinQianUp : EventBase
{
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("金钱UP触发了");
        GameData.GetInstance().Upgrade_Available = false;
        GameData.GetInstance().Money_Output_Fix *= 2f;
    }
}
