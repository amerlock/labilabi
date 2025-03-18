using System.ComponentModel.DataAnnotations;

namespace Social.Domain.Model;
/// <summary>
/// Класс пользователь
/// </summary>
public class Users
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    [Required]
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Имя пользователя
    /// </summary>
    [Required]
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Отчество пользователя
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Пол пользователя
    /// </summary>
    [Required]
    public Gender Sex { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public int? DateOfBirth { get; set; }

    /// <summary>
    /// Дата регистрации
    /// </summary>
    public int? DateOfRegistration { get; set; }
}