using System.Text.Json.Serialization;
namespace UserPanel.Models
{
    public class ItemCategory
    {
        [JsonPropertyName("id")] public required int Id { get; set; }
        [JsonPropertyName("name")] public required string Name { get; set; }
        [JsonPropertyName("code")] public required string Code { get; set; }
    }
}
