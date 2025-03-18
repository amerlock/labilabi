using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social.Domain.Model;
/// <summary>
/// Класс записей пользователей в группе
/// </summary>
public class UserRecordGroup
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Заголовок записи
    /// </summary>
    [Required]
    public string Header { get; set; } = null!;

    /// <summary>
    /// Описание записи
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Автор записи
    /// </summary>
    public Users Author { get; set; } = null!;
    /// <summary>
    /// Ссылка на группу, в которой опубликована запись
    /// </summary>
    public Group Group { get; set; } = null!;
}
