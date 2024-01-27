using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EL_FanMaiZhuanLi : EventBase
{
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("贩卖专利触发了");
        GameData.GetInstance().Money_Output_Fix *= 0.5f;
        GameData.GetInstance().Draw_Card_Required_Money /=2;
    }
}
