namespace UserPanel.Models;

public class RegRequest
{
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string UserPatronymic { get; set; }
    public bool Sex { get; set; }
    public DateTime Birthday { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string AvatarUrl { get; set; }
}

public class RegResponse
{
    public User User { get; set; }
    public string Token { get; set; }
}
