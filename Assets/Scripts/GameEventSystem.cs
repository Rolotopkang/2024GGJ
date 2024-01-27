using System;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class GameEventSystem : Singleton<GameEventSystem>, IGameService
{
    private List<EventBase> _eventBasesList;
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
        CreateEventIcon(eventSo, tmpEvent);
        
    }

    private void CreateEventIcon(EventSO eventSo, EventBase eventBase)
    {
        
    }
}
