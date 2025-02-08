using System.Text.Json.Serialization;
namespace UserPanel.Models;
public class Comment
{
    [JsonPropertyName("id")] public required ulong Id { get; set; }
    [JsonPropertyName("text")] public required string Text { get; set; }
    [JsonPropertyName("user_id")] public required ulong UserId { get; set; }
    [JsonPropertyName("article_id")] public required ulong ArticleId { get; set; }
    [JsonPropertyName("created_at")] public required DateTime CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public required DateTime UpdatedAt { get; set; }
    [JsonPropertyName("user")] public User? User { get; set; }
}