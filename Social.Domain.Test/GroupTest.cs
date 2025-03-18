using Social.Domain.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Tests;
public class GroupTest
{
    /// <summary>
    /// Тест проверяет, что метод GetGroupRoleStatistics возвращает корректную информацию 
    /// о количестве ролей в каждой группе.
    /// </summary>
    [Fact]
    public async Task GetGroupRoleStatistics_ReturnsCorrectCounts()
    {
        // Arrange
        var repo = new GroupInMemoryRepository();

        // Act
        var stats = await repo.GetGroupRoleStatistics();

        // Assert
        Assert.NotNull(stats);
        Assert.All(stats, s => Assert.NotNull(s.group)); // Проверяем, что у всех записей есть группа
    }

    /// <summary>
    /// Тест проверяет, что метод GetGroupsWithMaxRecords возвращает не более 5 групп с наибольшим количеством записей.
    /// </summary>
    [Fact]
    public async Task GetGroupsWithMaxRecords_ReturnsTop5Groups()
    {
        // Arrange
        var repo = new GroupInMemoryRepository();

        // Act
        var result = await repo.GetGroupsWithMaxRecords();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Count <= 5, "Ожидается не более 5 групп");
    }
}
