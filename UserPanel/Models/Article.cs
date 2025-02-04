using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace UserPanel.Models;
public class Article
{
    [JsonPropertyName("id")] public required ulong Id { get; set; }
    [JsonPropertyName("text")] public required string Text { get; set; }
    [JsonPropertyName("title")] public required string Title { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("preview")] public required string Preview { get; set; }
    [JsonPropertyName("author_id")] public required ulong AuthorId { get; set; }
    [JsonPropertyName("article_category_id")] public required ulong ArticleCategoryId { get; set; }
    [JsonPropertyName("created_at")] public required DateTime CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public required DateTime UpdatedAt { get; set; }

    // Добавляем свойство Author для автора статьи
    [JsonPropertyName("author")] public User? Author { get; set; }

    // Список комментариев
    [JsonPropertyName("comments")] public List<Comment>? Comments { get; set; }
}