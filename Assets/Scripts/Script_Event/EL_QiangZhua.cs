using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EL_QiangZhua : EventBase
{
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("强抓科技触发了");
        GameData.GetInstance().industry_Return_Rate_Base_Num *= 0;
        GameData.GetInstance().science_Return_Rate_Base_Num *= 0;
        GameData.GetInstance().finance_Return_Rate_Base_Num *= 0;
    }
}
