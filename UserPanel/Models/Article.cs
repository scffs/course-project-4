using System.Text.Json.Serialization;
namespace UserPanel.Models;

public class Article
{
    [JsonPropertyName("id")] public required int Id { get; set; }
    [JsonPropertyName("text")] public required string Text { get; set; }
    [JsonPropertyName("title")] public required string Title { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("preview")] public required string Preview { get; set; }
    [JsonPropertyName("article_category")] public ArticleCategory? ArticleCategory { get; set; }
    [JsonPropertyName("comments")] public List<Comment>? Comments { get; set; } = [];
    [JsonPropertyName("author")] public User? Author { get; set; }

}
