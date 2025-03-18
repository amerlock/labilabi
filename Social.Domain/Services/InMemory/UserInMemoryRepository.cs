using Social.Domain.Model;
using Social.Domain.Data;
using Social.Domain.Services;

namespace Social.Domain.Services.InMemory;

/// <summary>
/// Репозиторий для работы с пользователями в памяти.
/// </summary>
public class UserInMemoryRepository : IUserRepository
{
    public readonly List<Users> _users;
    public readonly List<UserRecordGroup> _records;

    public UserInMemoryRepository()
    {
        _users = DataSeeder.Users;
        _records = DataSeeder.UserRecords;
    }

    public Task<IList<Users>> GetAll()
    {
        return Task.FromResult<IList<Users>>(_users);
    }

    public Task<Users?> Get(int key)
    {
        var user = _users.FirstOrDefault(u => u.Id == key);
        return Task.FromResult(user);
    }

    public Task<Users> Add(Users entity)
    {
        if (!_users.Any(u => u.Id == entity.Id))
        {
            _users.Add(entity);
        }
        return Task.FromResult(entity);
    }

    public Task<Users> Update(Users entity)
    {
        var existingUser = _users.FirstOrDefault(u => u.Id == entity.Id);
        if (existingUser != null)
        {
            existingUser.FirstName = entity.FirstName;
            existingUser.LastName = entity.LastName;
            existingUser.Patronymic = entity.Patronymic;
            existingUser.Sex = entity.Sex;
            existingUser.DateOfBirth = entity.DateOfBirth;
            existingUser.DateOfRegistration = entity.DateOfRegistration;
        }
        return Task.FromResult(entity);
    }

    public Task<bool> Delete(int key)
    {
        var user = _users.FirstOrDefault(u => u.Id == key);
        if (user != null)
        {
            _users.Remove(user);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    /// <summary>
    /// Получить всех пользователей заданной группы, упорядочить по ФИО.
    /// </summary>
    public Task<IList<Users>> GetUsersByGroupOrderedByFullName(int groupId)
    {
        var users = _records
            .Where(r => r.Group?.Id == groupId && r.Author != null)
            .Select(r => r.Author)
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .ThenBy(u => u.Patronymic)
            .Distinct()
            .ToList();

        return Task.FromResult<IList<Users>>(users);
    }

    /// <summary>
    /// Вывести топ 5 пользователей по созданным записям за указанный период.
    /// </summary>
    public Task<IList<(Users user, int recordCount)>> GetTop5UsersByRecordsInPeriod(DateTime startDate, DateTime endDate)
    {
        var topUsers = _records
            .Where(r => r.CreatedDate >= startDate && r.CreatedDate <= endDate)
            .GroupBy(r => r.Author)
            .Select(g => (User: g.Key, RecordCount: g.Count()))
            .OrderByDescending(x => x.RecordCount)
            .Take(5)
            .ToList();

        return Task.FromResult<IList<(Users, int)>>(topUsers);
    }
}
