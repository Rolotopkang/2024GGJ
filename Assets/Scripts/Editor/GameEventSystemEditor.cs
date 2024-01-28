using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameEventSystem))]
public class GameEventSystemEditor : Editor
{
    private int id;
    public override void OnInspectorGUI()
    { 
        
        GameEventSystem GameEventSystem = (GameEventSystem)target;
        DrawDefaultInspector();
        
        EditorGUILayout.LabelField("测试区：");
        if (GUILayout.Button("添加随机大事件"))
        {
            GameEventSystem.CreateGameEvent(ServiceLocator.Current.Get<IEventInfoService>().GetRandomBigEventSo());
        }
        if (GUILayout.Button("添加随机小事件"))
        {
            GameEventSystem.CreateGameEvent(ServiceLocator.Current.Get<IEventInfoService>().GetRandomSmallEventSo());
        }
        
        EditorGUILayout.LabelField("生成指定ID事件：");
        id = EditorGUILayout.IntField(id);
        if (GUILayout.Button("生成事件"))
        {
            GameEventSystem.CreateGameEvent(ServiceLocator.Current.Get<IEventInfoService>().GetEventSOByID(id));
        }
    }

    
}
