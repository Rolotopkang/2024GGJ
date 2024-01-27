using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventButtonManager : Singleton<EventButtonManager>
{
    public GameObject EventButtonPrefab;

    public void GenerateButton(EventSO eventSo, EventBase eventBase)
    {
        GameObject tmp_eventButton= Instantiate(EventButtonPrefab, transform);
        tmp_eventButton.GetComponent<EventButton>().Init(eventSo , eventBase);
    }
}
