using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EventInfoService : MonoBehaviour , IEventInfoService
{
    [FormerlySerializedAs("itemDataList")] public List<EventSO> eventDataList = new List<EventSO>();

    private void Awake()
    {
        var _getSources = Resources.LoadAll<EventSO>("SO");
        foreach (EventSO source in _getSources)
        {
            eventDataList.Add(source);
        }
        Debug.Log("事件SO注册完毕");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public EventSO GetEventSOByID(int id)
    {
        foreach (EventSO EventSO in eventDataList)
        {
            if (id.Equals(EventSO.ID))
                return EventSO;
        }

        Debug.LogError("没有找到对应ID的鱼");
        return null;
    }

    /// <summary>
    /// 获取一个随机事件
    /// </summary>
    /// <returns></returns>
    public EventSO GetRandomEventSo()
    {
        return eventDataList[Random.Range(0, eventDataList.Count)];
    }
    
    /// <summary>
    /// 获取事件列表
    /// </summary>
    /// <returns></returns>
    public List<EventSO> GetEventSOList()
    {
        return eventDataList;
    }
}