using System;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class GameEventSystem : Singleton<GameEventSystem>, IGameService
{
    private List<EventBase> _eventBasesList = new();
    private IEventInfoService EventInfoService;

    private void Start()
    {
        // EventInfoService = ServiceLocator.Current.Get<IEventInfoService>();
        // EventInfoService.GetRandomEventSo().Event.TriggerEvent();
    }

    /// <summary>
    /// 通过SO创建事件
    /// </summary>
    /// <param name="eventSo"></param>
    public void CreateGameEvent(EventSO eventSo)
    {
        EventBase tmpEvent = Instantiate(eventSo.Event, this.transform);
        tmpEvent.eventSo = eventSo;
        _eventBasesList.Add(tmpEvent);
        tmpEvent.Init();
        CreateEventIcon(eventSo, tmpEvent);
        
    }

    private void CreateEventIcon(EventSO eventSo, EventBase eventBase)
    {
        EventButtonManager.GetInstance().GenerateButton(eventSo,eventBase);
    }

    /// <summary>
    /// 事件结算回合调用
    /// </summary>
    public void OnEndRound()
    {
        for (int i = 0; i < _eventBasesList.Count; i++)
        {
            _eventBasesList[i].TriggerEvent();
        }
    }

    public void DelEvent(EventBase eventBase)
    {
        EventBase tmpdelEventBase = null;
        foreach (EventBase tmp_eventBase in _eventBasesList)
        {
            if (tmp_eventBase.Equals(eventBase))
            {
                tmpdelEventBase = tmp_eventBase;
            }
        }

        if (tmpdelEventBase == null)
        {
            Debug.LogError("没找到需要删除的事件");
        }
        _eventBasesList.Remove(tmpdelEventBase);
        Destroy(tmpdelEventBase.gameObject);
    }
}
