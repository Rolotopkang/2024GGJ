using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class EventButton : MonoBehaviour
{
    public Text ButtonText;
    public ColorController ButtonColor;
    public ColorController EventColor;
    public Image EventImage;
    public Text EventName;
    public Text EventDis;
    public Text EventState;
    public GameObject EventInfoGO;

    private EventSO EventSo;
    private EventBase EventBase;
    
    
    public void Init(EventSO eventSo , EventBase eventBase)
    {
        eventBase.OnEventCanceled += () => { Destroy(gameObject); };
        EventSo = eventSo;
        EventBase = eventBase;
        ButtonText.text = eventSo.EventName;
        EventImage.sprite = eventSo.EventSprite;
        EventName.text = eventSo.EventName;
        EventDis.text = eventSo.Discription;
        ButtonColor.ChangeColorState(EventSo.IsBigEvent?
            ColorController.ColorState.Grew 
            :ColorController.ColorState.Rainbow);
        EventColor.ChangeColorState(EventSo.IsBigEvent?
            ColorController.ColorState.Grew 
            :ColorController.ColorState.Rainbow);
        EventInfoGO.SetActive(false);
    }

    private void Update()
    {
        if (EventBase.active)
        {
            EventState.text = new StringBuilder("剩余").Append(EventBase.LastRound).Append("回合").ToString();
        }
        else
        {
            EventState.text = new StringBuilder("还有").Append(EventBase.WaitRound).Append("回合触发事件").ToString();
        }
    }
}
