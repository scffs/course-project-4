﻿using System.Text.Json.Serialization;
namespace UserPanel.Models;
public class Item
{
    [JsonPropertyName("id")] public required ulong Id { get; set; }
    [JsonPropertyName("title")] public required string Title { get; set; }
    [JsonPropertyName("is_activated")] public required bool IsActivated { get; set; }
    [JsonPropertyName("preview_url")] public required string PreviewUrl { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("price")] public required decimal Price { get; set; }
    [JsonPropertyName("item_category")] public ItemCategory? ItemCategory { get; set; }

}