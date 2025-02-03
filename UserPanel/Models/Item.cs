using System.Text.Json.Serialization;

namespace UserPanel.Models;
public class Item
{
    [JsonPropertyName("id")] public required ulong Id { get; set; }
    [JsonPropertyName("title")] public required string Title { get; set; }
    [JsonPropertyName("is_activated")] public required bool IsActivated { get; set; }
    [JsonPropertyName("preview_url")] public required string PreviewUrl { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("price")] public required decimal Price { get; set; }
    [JsonPropertyName("item_category_id")] public required ulong ItemCategoryId { get; set; }
    [JsonPropertyName("created_at")] public required DateTime CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public required DateTime UpdatedAt { get; set; }
}