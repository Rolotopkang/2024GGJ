using UnityEngine;

[CreateAssetMenu(fileName = "NewEvent", menuName = "GameEventSystem/Event")]
public class EventSO : ScriptableObject
{
    //事件ID
    public int ID;

    public bool IsBigEvent;

    //事件名
    public string EventName;
    
    //描述
    public string Discription;

    public Sprite EventSprite;

    //事件脚本
    public EventBase Event;

    public int EventLastTime;
    public int EventWaitTime;
}
