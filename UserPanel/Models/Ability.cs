using System.Text.Json.Serialization;
namespace UserPanel.Models;
public class Ability
{
    [JsonPropertyName("id")] public required int Id { get; set; }
    [JsonPropertyName("name")] public required string Name { get; set; }
    [JsonPropertyName("description")] public required string Description { get; set; }
    [JsonPropertyName("photo_url")] public required string PhotoUrl { get; set; }
}