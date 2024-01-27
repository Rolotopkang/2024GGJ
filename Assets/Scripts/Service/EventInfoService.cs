using System;
using System.Collections.Generic;
using UnityEngine;

public class EventInfoService : MonoBehaviour , IEventInfoService
{
    public List<EventSO> itemDataList = new List<EventSO>();
    public EventSO BaseItem = null;

    private void Awake()
    {
        var _getSources = Resources.LoadAll<EventSO>("SO");
        foreach (EventSO source in _getSources)
        {
            if (source.ID == 100)
            {
                BaseItem = source;
            }
            itemDataList.Add(source);
        }

        if (BaseItem == null)
        {
            Debug.LogError("SO缺少基本道具");
        }
        Debug.Log("物品SO注册完毕");
    }

    public EventSO GetEventSOByID(int id)
    {
        foreach (EventSO EventSO in itemDataList)
        {
            if (id.Equals(EventSO.ID))
                return EventSO;
        }

        Debug.LogError("没有找到对应ID的鱼");
        return BaseItem;
    }
    
    public List<EventSO> GetEventSOList()
    {
        return itemDataList;
    }
}