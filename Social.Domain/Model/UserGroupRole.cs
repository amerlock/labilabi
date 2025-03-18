using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Model;
/// <summary>
/// Класс описывающий роли пользователей в группе
/// </summary>
public enum UserRole
{
    Admin,
    Moderator,
    Contributor,
    Reader
}

public class UserGroupRole
{
    /// <summary>
    /// Индифинатор пользователя
    /// </summary>
    public int UserId { get; set; }
    /// <summary>
    /// Индифинатор группы
    /// </summary>
    public int GroupId { get; set; }
    /// <summary>
    /// Роль пользователя в группе
    /// </summary>
    public UserRole Role { get; set; }
}
