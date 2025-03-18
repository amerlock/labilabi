using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social.Domain.Model;
/// <summary>
/// Класс группы
/// </summary>
public class Group
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Название группы
    /// </summary>
    [Required]
    public string Title { get; set; } = null!;

    /// <summary>
    /// Описание группы
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Дата создания группы
    /// </summary>
    public int? CreatedDate { get; set; }

    /// <summary>
    /// Автор группы
    /// </summary>
    public Users Author { get; set; } = null!;
}
