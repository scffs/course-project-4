using System.Text.Json.Serialization;
namespace UserPanel.Models;
public class User
{
    [JsonPropertyName("id")] public required ulong Id { get; set; }
    [JsonPropertyName("name")] public required string Name { get; set; }
    [JsonPropertyName("surname")] public required string Surname { get; set; }
    [JsonPropertyName("patronymic")] public string? Patronymic { get; set; }
    [JsonPropertyName("sex")] public required bool Sex { get; set; }
    [JsonPropertyName("birthday")] public required DateTime Birthday { get; set; }
    [JsonPropertyName("status")] public string? Status { get; set; }
    [JsonPropertyName("login")] public required string Login { get; set; }
    [JsonPropertyName("avatar_url")] public string? AvatarUrl { get; set; }
    [JsonPropertyName("role_id")] public required ulong RoleId { get; set; }
}