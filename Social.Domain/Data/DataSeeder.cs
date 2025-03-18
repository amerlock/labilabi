using Social.Domain.Model;

namespace Social.Domain.Data;

/// <summary>
/// Класс для заполнения коллекций данными
/// </summary>
public static class DataSeeder
{
    /// <summary>
    /// Коллекция пользователей для начального наполнения
    /// </summary>
    public static readonly List<Users> Users =
    [
        new() { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Sex = Gender.Male, DateOfBirth = 19800115, DateOfRegistration = 20240110 },
        new() { Id = 2, LastName = "Петров", FirstName = "Петр", Patronymic = "Петрович", Sex = Gender.Male, DateOfBirth = 19850322, DateOfRegistration = 20240211 },
        new() { Id = 3, LastName = "Сидорова", FirstName = "Анна", Patronymic = "Андреевна", Sex = Gender.Female, DateOfBirth = 19900215, DateOfRegistration = 20240305 },
        new() { Id = 4, LastName = "Кузнецов", FirstName = "Алексей", Patronymic = "Алексеевич", Sex = Gender.Male, DateOfBirth = 19951212, DateOfRegistration = 20240120 },
        new() { Id = 5, LastName = "Федорова", FirstName = "Мария", Patronymic = "Игоревна", Sex = Gender.Female, DateOfBirth = 19971230, DateOfRegistration = 20240228 }
    ];

    /// <summary>
    /// Коллекция групп для начального наполнения
    /// </summary>
    public static readonly List<Group> Groups =
    [
        new() { Id = 1, Title = "Разработка", Description = "Группа для разработчиков", CreatedDate = 20240115, Author = Users[0] },
        new() { Id = 2, Title = "Маркетинг", Description = "Группа для маркетологов", CreatedDate = 20240205, Author = Users[1] },
        new() { Id = 3, Title = "Дизайн", Description = "Группа для дизайнеров", CreatedDate = 20240301, Author = Users[2] }
    ];

    /// <summary>
    /// Коллекция ролей пользователей в группах
    /// </summary>
    public static readonly List<UserGroupRole> UserRoles =
    [
        new() { UserId = 1, GroupId = 1, Role = UserRole.Admin },
        new() { UserId = 2, GroupId = 1, Role = UserRole.Moderator },
        new() { UserId = 3, GroupId = 2, Role = UserRole.Contributor },
        new() { UserId = 4, GroupId = 3, Role = UserRole.Reader },
        new() { UserId = 5, GroupId = 3, Role = UserRole.Admin }
    ];

    /// <summary>
    /// Коллекция записей пользователей в группах
    /// </summary>
    public static readonly List<UserRecordGroup> UserRecords =
    [
        new() { Id = 1, Header = "Первый пост", Description = "Описание первого поста", Author = Users[0] },
        new() { Id = 2, Header = "Маркетинговый ход", Description = "Описание маркетингового хода", Author = Users[1] },
        new() { Id = 3, Header = "Дизайн логотипа", Description = "Описание дизайна логотипа", Author = Users[2] },
        new() { Id = 4, Header = "Технический пост", Description = "Описание технического поста", Author = Users[3] },
        new() { Id = 5, Header = "Советы по дизайну", Description = "Описание советов по дизайну", Author = Users[4] }
    ];
}
