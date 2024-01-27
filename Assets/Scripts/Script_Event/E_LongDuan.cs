using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class E_LongDuan : EventBase
{
    [SerializeField]
    private float Money_Available_Fix = 0.6f;
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("垄断触发了");
        Global.GetInstance().SetProfessionLevel_One(2);
        GameData.GetInstance().Money_Output_Fix = 0.5f;
        GameData.GetInstance().Money_Available_Fix = Money_Available_Fix;
    }
}
