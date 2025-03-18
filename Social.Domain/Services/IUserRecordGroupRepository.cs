using Social.Domain.Model;

namespace Social.Domain.Services;

/// <summary>
/// Репозиторий для работы с записями пользователей в группах.
/// </summary>
public interface IUserRecordGroupRepository : IRepository<UserRecordGroup, int>
{
    /// <summary>
    /// Получить все записи, опубликованные в указанной группе, в порядке публикации.
    /// </summary>
    /// <param name="groupId">Идентификатор группы.</param>
    /// <returns>Список записей.</returns>
    public Task<IList<UserRecordGroup>> GetRecordsByGroupOrderedByDate(int groupId);

    /// <summary>
    /// Получить суммарное число записей в каждой группе.
    /// </summary>
    /// <returns>Список групп с количеством записей.</returns>
    public Task<IList<(Group group, int recordCount)>> GetRecordCountByGroup();
}
