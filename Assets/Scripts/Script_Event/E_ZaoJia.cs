using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ZaoJia : EventBase
{
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("造假触发了");
        Global.GetInstance().SetProfessionLevel_One(1);
        GameData.GetInstance().Draw_Card_Available = false;
        GameData.GetInstance().Upgrade_Available = false;
    }
}
