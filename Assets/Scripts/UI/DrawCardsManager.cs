using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardsManager : Singleton<DrawCardsManager>
{
    public EventCard CardPrefab;

    private EventCard zuo;
    private EventCard zhong;
    private EventCard you;

    private void OnEnable()
    {
        GenerateCards(ServiceLocator.Current.Get<IEventInfoService>().Get3RandomSmallEventSo());
    }

    public void GenerateCards(List<EventSO> eventSos)
    {
        zuo = Instantiate(CardPrefab, transform);
        zuo.Init(eventSos[0],() => {transform.parent.gameObject.SetActive(false); });
        zhong = Instantiate(CardPrefab, transform);
        zhong.Init(eventSos[1],() => {transform.parent.gameObject.SetActive(false); });
        you = Instantiate(CardPrefab, transform);
        you.Init(eventSos[2],() => {transform.parent.gameObject.SetActive(false); });
    }

    private void OnDisable()
    {
        Destroy(zuo.gameObject);
        Destroy(zhong.gameObject);
        Destroy(you.gameObject);
    }
}
