using Social.Domain.Model;
using Social.Domain.Data;
using Social.Domain.Services;

namespace Social.Domain.Services.InMemory;

/// <summary>
/// Репозиторий для работы с записями пользователей в группах в памяти
/// </summary>
public class UserRecordGroupInMemoryRepository : IUserRecordGroupRepository
{
    public readonly List<UserRecordGroup> _records;

    public UserRecordGroupInMemoryRepository()
    {
        _records = DataSeeder.UserRecords;
    }
    /// <inheritdoc/>
    public Task<IList<UserRecordGroup>> GetAll()
    {
        return Task.FromResult<IList<UserRecordGroup>>(_records);
    }
    /// <inheritdoc/>
    public Task<UserRecordGroup?> Get(int key)
    {
        var record = _records.FirstOrDefault(r => r.Id == key);
        return Task.FromResult(record);
    }
    /// <inheritdoc/>
    public Task<UserRecordGroup> Add(UserRecordGroup entity)
    {
        if (!_records.Any(r => r.Id == entity.Id))
        {
            _records.Add(entity);
        }
        return Task.FromResult(entity);
    }
    /// <inheritdoc/>
    public Task<UserRecordGroup> Update(UserRecordGroup entity)
    {
        var existingRecord = _records.FirstOrDefault(r => r.Id == entity.Id);
        if (existingRecord != null)
        {
            existingRecord.Header = entity.Header;
            existingRecord.Description = entity.Description;
            existingRecord.CreatedDate = entity.CreatedDate;
            existingRecord.Author = entity.Author;
        }
        return Task.FromResult(entity);
    }
    /// <inheritdoc/>
    public Task<bool> Delete(int key)
    {
        var record = _records.FirstOrDefault(r => r.Id == key);
        if (record != null)
        {
            _records.Remove(record);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
    /// <summary>
    /// Получить все записи, опубликованные в указанной группе.
    /// </summary>
    public Task<IList<UserRecordGroup>> GetRecordsByGroupOrderedByDate(int groupId)
    {
        var records = _records
            .Where(r => r.Group != null && r.Group.Id == groupId)
            .ToList();

        return Task.FromResult<IList<UserRecordGroup>>(records);
    }

    /// <summary>
    /// Получить количество записей в каждой группе.
    /// </summary>
    public Task<IList<(Group group, int recordCount)>> GetRecordCountByGroup()
    {
        var counts = _records
            .Where(r => r.Group != null)  // Фильтруем записи, где группа не равна null
            .GroupBy(r => r.Group)
            .Select(g => (Group: g.Key, RecordCount: g.Count()))
            .ToList();

        return Task.FromResult<IList<(Group, int)>>(counts);
    }
}
