
using System;
using UnityEngine;

[Serializable]
public class E_HuangZai : EventBase
{
    protected override void EventTrigger()
    {
        base.EventTrigger();
        Debug.Log("蝗灾触发了");
        Global.GetInstance().SetProfessionLevel_One(0);
        GameData.GetInstance().supplies_Consume_Fix *= 1.5f;
        GameData.GetInstance().Supplies_Output_Fix *= 0.5f;
    }
}
