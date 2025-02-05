using System.Text.Json.Serialization;

namespace UserPanel.Models.Response;

public class AuthResponse
{
  [JsonPropertyName("user")] public required User User { get; set; }
  [JsonPropertyName("token")] public required string Token { get; set; }
}