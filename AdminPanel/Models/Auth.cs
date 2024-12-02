namespace AdminPanel.Models;

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class AuthResponse
{
    public User User { get; set; }
    public string Token { get; set; }
}