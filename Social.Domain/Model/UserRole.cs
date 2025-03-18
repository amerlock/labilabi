using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Model;
/// <summary>
/// Перечисление, описывающее роли пользователей в группе.
/// </summary>
public enum UserRole
{
    Admin,
    Moderator,
    Contributor,
    Reader
}
