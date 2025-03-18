using Social.Domain.Model;

namespace Social.Domain.Services;

/// <summary>
/// Репозиторий для работы с группами.
/// </summary>
public interface IGroupRepository : IRepository<Group, int>
{
    /// <summary>
    /// Получить информацию о количестве администраторов, модераторов, соавторов и читателей в каждой группе.
    /// </summary>
    /// <returns>Список групп с количеством ролей.</returns>
    public Task<IList<(Group group, int adminCount, int moderatorCount, int contributorCount, int readerCount)>> GetGroupRoleStatistics();

    /// <summary>
    /// Получить информацию о группах, в которых опубликовано максимальное число записей.
    /// </summary>
    /// <returns>Список групп с максимальным количеством записей.</returns>
    public Task<IList<(Group group, int recordCount)>> GetGroupsWithMaxRecords();
}
