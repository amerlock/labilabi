using Social.Domain.Model;
using Social.Domain.Data;
using Social.Domain.Services;
using System.Data;

namespace Social.Domain.Services.InMemory;

/// <summary>
/// Репозиторий для работы с группами в памяти.
/// </summary>
public class GroupInMemoryRepository : IGroupRepository
{
    public readonly List<Group> _groups;
    public readonly List<UserGroupRole> _roles;
    public readonly List<UserRecordGroup> _records;

    public GroupInMemoryRepository()
    {
        _groups = DataSeeder.Groups;
        _roles = DataSeeder.UserRoles;
        _records = DataSeeder.UserRecords;
    }

    public Task<IList<Group>> GetAll()
    {
        return Task.FromResult<IList<Group>>(_groups);
    }

    public Task<Group?> Get(int key)
    {
        var group = _groups.FirstOrDefault(g => g.Id == key);
        return Task.FromResult(group);
    }

    public Task<Group> Add(Group entity)
    {
        if (!_groups.Any(g => g.Id == entity.Id))
        {
            _groups.Add(entity);
        }
        return Task.FromResult(entity);
    }

    public Task<Group> Update(Group entity)
    {
        var existingGroup = _groups.FirstOrDefault(g => g.Id == entity.Id);
        if (existingGroup != null)
        {
            existingGroup.Title = entity.Title;
            existingGroup.Description = entity.Description;
            existingGroup.CreatedDate = entity.CreatedDate;
            existingGroup.Author = entity.Author;
        }
        return Task.FromResult(entity);
    }

    public Task<bool> Delete(int key)
    {
        var group = _groups.FirstOrDefault(g => g.Id == key);
        if (group != null)
        {
            _groups.Remove(group);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    /// <summary>
    /// Получить информацию о количестве ролей в каждой группе.
    /// </summary>
    public Task<IList<(Group group, int adminCount, int moderatorCount, int contributorCount, int readerCount)>> GetGroupRoleStatistics()
    {
        var stats = _groups
            .Select(g => (
            Group: g,
                AdminCount: _roles.Count(r => r.GroupId == g.Id && r.Role == UserRole.Admin),
                ModeratorCount: _roles.Count(r => r.GroupId == g.Id && r.Role == UserRole.Moderator),
                ContributorCount: _roles.Count(r => r.GroupId == g.Id && r.Role == UserRole.Contributor),
                ReaderCount: _roles.Count(r => r.GroupId == g.Id && r.Role == UserRole.Reader)
            ))
            .ToList();

        return Task.FromResult<IList<(Group, int, int, int, int)>>(stats);
    }

    /// <summary>
    /// Получить группы с максимальным количеством записей.
    /// </summary>
    public Task<IList<(Group group, int recordCount)>> GetGroupsWithMaxRecords()
    {
        var maxRecordCount = _records
            .GroupBy(r => r.Group)
            .Select(g => (Group: g.Key, RecordCount: g.Count()))
            .OrderByDescending(x => x.RecordCount)
            .Take(5)
            .ToList();

        return Task.FromResult<IList<(Group, int)>>(maxRecordCount);
    }
}
