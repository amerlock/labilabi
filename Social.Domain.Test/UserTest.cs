using Social.Domain.Model;
using Social.Domain.Services.InMemory;

namespace Social.Domain.Tests;

/// <summary>
/// Тесты для UserInMemoryRepository
/// </summary>
public class UserInMemoryRepositoryTests
{
    /// <summary>
    /// Тест проверяет, что метод GetUsersByGroupOrderedByFullName возвращает пользователей 
    /// указанной группы, упорядоченных по фамилии, имени и отчеству.
    /// </summary>
    [Fact]
    public async Task GetUsersByGroupOrderedByFullName_ReturnsOrderedUsers()
    {
        // Arrange
        var repo = new UserInMemoryRepository();
        var groupId = 1;

        // Act
        var users = await repo.GetUsersByGroupOrderedByFullName(groupId);

        // Assert
        Assert.NotNull(users);
        Assert.True(users.SequenceEqual(users.OrderBy(u => u.LastName)
                                            .ThenBy(u => u.FirstName)
                                            .ThenBy(u => u.Patronymic)),
                    "Список пользователей должен быть отсортирован по ФИО");
    }

    /// <summary>
    /// Тест проверяет, что метод GetTop5UsersByRecordsInPeriod возвращает топ-5 пользователей 
    /// по количеству созданных записей за указанный период.
    /// </summary>
    [Fact]
    public async Task GetTop5UsersByRecordsInPeriod_ReturnsTop5Users()
    {
        // Arrange
        var repo = new UserInMemoryRepository();
        DateTime start = DateTime.Now.AddMonths(-1);
        DateTime end = DateTime.Now;

        // Act
        var users = await repo.GetTop5UsersByRecordsInPeriod(start, end);

        // Assert
        Assert.NotNull(users);
        Assert.True(users.Count <= 5, "Ожидается не более 5 пользователей");
    }
}
