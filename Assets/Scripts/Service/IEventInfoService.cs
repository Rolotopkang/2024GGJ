using System.Collections.Generic;

public interface IEventInfoService : IGameService
{
    /// <summary>
    /// 通过ID找事件的SO
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public EventSO GetEventSOByID(int id);

    /// <summary>
    /// 获取事件列表
    /// </summary>
    /// <returns></returns>
    public List<EventSO> GetEventSOList();

    /// <summary>
    /// 获取一个随机大事件
    /// </summary>
    /// <returns></returns>
    public EventSO GetRandomBigEventSo();

    /// <summary>
    /// 获取三个不重复随机小事件
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public List<EventSO> Get3RandomSmallEventSo();
    
    /// <summary>
    /// 获取一个随机小事件
    /// </summary>
    /// <returns></returns>
    public EventSO GetRandomSmallEventSo();
}