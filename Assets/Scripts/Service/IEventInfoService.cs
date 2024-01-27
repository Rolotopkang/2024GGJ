using System.Collections.Generic;

public interface IEventInfoService : IGameService
{
    /// <summary>
    /// 通过ID找物品的SO
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public EventSO GetEventSOByID(int id);

    public List<EventSO> GetEventSOList();
}