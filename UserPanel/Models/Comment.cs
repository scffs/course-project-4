using System.Text.Json.Serialization;
namespace UserPanel.Models;
public class Comment
{
    [JsonPropertyName("id")] public required int Id { get; set; }
    [JsonPropertyName("text")] public required string Text { get; set; }
    [JsonPropertyName("user_id")] public required int UserId { get; set; }
    [JsonPropertyName("article_id")] public required int ArticleId { get; set; }
}