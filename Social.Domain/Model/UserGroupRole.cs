using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Model;
/// <summary>
/// Класс, описывающий роли пользователей в группе.
/// </summary>
public class UserGroupRole
{
    /// <summary>
    /// Индификатор пользователя.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Индификатор группы.
    /// </summary>
    public int GroupId { get; set; }

    /// <summary>
    /// Роль пользователя в группе.
    /// </summary>
    public UserRole Role { get; set; }
}
