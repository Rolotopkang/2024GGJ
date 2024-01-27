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
    /// 获取一个随机事件
    /// </summary>
    /// <returns></returns>
    public EventSO GetRandomEventSo();
}