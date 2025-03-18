using Social.Domain.Model;

namespace Social.Domain.Services;

/// <summary>
/// Репозиторий для работы с пользователями.
/// </summary>
public interface IUserRepository : IRepository<Users, int>
{
    /// <summary>
    /// Получить всех пользователей заданной группы, упорядочить по ФИО.
    /// </summary>
    /// <param name="groupId">Идентификатор группы.</param>
    /// <returns>Список пользователей.</returns>
    public Task<IList<Users>> GetUsersByGroupOrderedByFullName(int groupId);

    /// <summary>
    /// Вывести топ 5 пользователей по созданным записям за указанный период.
    /// </summary>
    /// <param name="startDate">Дата начала периода.</param>
    /// <param name="endDate">Дата окончания периода.</param>
    /// <returns>Список пользователей с количеством записей.</returns>
    public Task<IList<(Users user, int recordCount)>> GetTop5UsersByRecordsInPeriod(DateTime startDate, DateTime endDate);
}
