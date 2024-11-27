using System;

namespace AdminPanel.Models;

public class User
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public bool Sex { get; set; }
    public DateTime Birthday { get; set; }
    public string Status { get; set; }
    public string Login { get; set; }
    public string AvatarUrl { get; set; }
    public string RoleId { get; set; }
}