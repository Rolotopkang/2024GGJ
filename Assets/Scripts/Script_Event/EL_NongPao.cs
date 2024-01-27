using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EL_NongPao : EventBase
{
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("农产品抛售触发了");
        GameData.GetInstance().Supplies_Output_Fix *= 2f;
        GameData.GetInstance().Science_Point_Output_Fix *= 2f;
        GameData.GetInstance().Money_Available_Fix *= 0.5f;
    }
}
