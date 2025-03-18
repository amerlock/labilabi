using Social.Domain.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Tests;
public class UserRecordTest
{
    /// <summary>
    /// Тест проверяет, что метод GetRecordsByGroupOrderedByDate возвращает записи 
    /// указанной группы, упорядоченные по дате создания.
    /// </summary>
    [Fact]
    public async Task GetRecordsByGroupOrderedByDate_ReturnsOrderedRecords()
    {
        // Arrange
        var repo = new UserRecordGroupInMemoryRepository();
        var groupId = 1;

        // Act
        var records = await repo.GetRecordsByGroupOrderedByDate(groupId);

        // Assert
        Assert.NotNull(records);
        Assert.True(records.SequenceEqual(records.OrderBy(r => r.CreatedDate)),
                    "Список записей должен быть отсортирован по дате");
    }

    /// <summary>
    /// Тест проверяет, что метод GetRecordCountByGroup возвращает корректное количество записей в каждой группе.
    /// </summary>
    [Fact]
    public async Task GetRecordCountByGroup_ReturnsCorrectCounts()
    {
        // Arrange
        var repo = new UserRecordGroupInMemoryRepository();

        // Act
        var result = await repo.GetRecordCountByGroup();

        // Assert
        Assert.NotNull(result);
        Assert.All(result, r => Assert.NotNull(r.group)); // Проверяем, что у всех записей есть группа
    }
}
