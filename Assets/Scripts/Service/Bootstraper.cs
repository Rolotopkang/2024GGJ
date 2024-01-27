using UnityEngine;


public class Bootstraper
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        //Initialize default service locator.
        ServiceLocator.Initialize();
        
        //注册事件SO
        var eventInfoObject = new GameObject("eventInfo");
        var eventInfoService = eventInfoObject.AddComponent<EventInfoService>();
        Object.DontDestroyOnLoad(eventInfoObject);
        ServiceLocator.Current.Register<IEventInfoService>(eventInfoService);
        
        //注册事件中心类
        var eventSystemObject = new GameObject("eventSystem");
        var eventSystem = eventSystemObject.AddComponent<GameEventSystem>();
        Object.DontDestroyOnLoad(eventSystemObject);
        ServiceLocator.Current.Register<GameEventSystem>(eventSystem);
    }
}