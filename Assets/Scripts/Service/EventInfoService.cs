using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EventInfoService : MonoBehaviour , IEventInfoService
{
    public List<EventSO> eventDataList = new List<EventSO>();
    
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

        Debug.LogError("没有找到对应ID的事件");
        return null;
    }

    /// <summary>
    /// 获取一个随机大事件
    /// </summary>
    /// <returns></returns>
    public EventSO GetRandomBigEventSo()
    {
        List<EventSO> tmp_eventsos = new List<EventSO>();
        foreach (EventSO EventSO in eventDataList)
        {
            if (EventSO.IsBigEvent)
            {
                tmp_eventsos.Add(EventSO);
            }
        }

        if (tmp_eventsos.Count <= 0)
        {
            Debug.LogError("没有大事件");
        }
        return tmp_eventsos[Random.Range(0, tmp_eventsos.Count)];
    }
    
    /// <summary>
    /// 获取三个不重复随机小事件
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public List<EventSO> Get3RandomSmallEventSo()
    {
        List<EventSO> tmp_littleEventsos = new List<EventSO>();
        foreach (EventSO SO in eventDataList)
        {
            if (!SO.IsBigEvent)
            {
                tmp_littleEventsos.Add(SO);
            }
        }
        
        // 确保列表中至少有三个元素
        if (tmp_littleEventsos.Count < 3)
        {
            throw new InvalidOperationException("Not enough elements in the list");
        }

        tmp_littleEventsos.Shuffle();

        // 选取前三个元素
        return tmp_littleEventsos.GetRange(0, 3);
    }
    
    /// <summary>
    /// 获取一个随机小事件
    /// </summary>
    /// <returns></returns>
    public EventSO GetRandomSmallEventSo()
    {
        List<EventSO> tmp_eventsos = new List<EventSO>();
        foreach (EventSO EventSO in eventDataList)
        {
            if (!EventSO.IsBigEvent)
            {
                tmp_eventsos.Add(EventSO);
            }
        }

        if (tmp_eventsos.Count <= 0)
        {
            Debug.LogError("没有little事件");
        }
        return tmp_eventsos[Random.Range(0, tmp_eventsos.Count)];
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