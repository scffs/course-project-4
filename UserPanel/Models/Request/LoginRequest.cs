using System.Text.Json.Serialization;
namespace UserPanel.Models.Request;
public class LoginRequest(string username, string password)
{
  [JsonPropertyName("username")] public string Username { get; set; } = username ?? throw new ArgumentNullException(nameof(username));
  [JsonPropertyName("password")] public string Password { get; set; } = password ?? throw new ArgumentNullException(nameof(password));
}