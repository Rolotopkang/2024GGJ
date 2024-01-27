using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventCard : MonoBehaviour
{
    public Text CardName;
    public Image CardImage;
    public Text CardDis;
    
    public void Init(EventSO eventSo, Action close)
    {
        CardName.text = eventSo.EventName;
        CardImage.sprite = eventSo.EventSprite;
        CardDis.text = eventSo.Discription;
        
        GetComponent<Button>().onClick.AddListener(() => 
            { GameEventSystem.GetInstance().CreateGameEvent(eventSo); });
        GetComponent<Button>().onClick.AddListener(()=>
            close());
    }
}
