using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_HanDong : EventBase
{
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("寒冬触发了");
        GameData.GetInstance().Money_Output_Fix *= 0.5f;
        GameData.GetInstance().Supplies_Output_Fix *= 0.5f;
        GameData.GetInstance().Science_Point_Output_Fix *= 0.5f;
        GameData.GetInstance().Draw_Card_Available = false;
    }
}
