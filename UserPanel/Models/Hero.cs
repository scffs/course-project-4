using System.Text.Json.Serialization;
namespace UserPanel.Models;
public class Hero
{
    [JsonPropertyName("id")] public required int Id { get; set; }
    [JsonPropertyName("name")] public required string Name { get; set; }
    [JsonPropertyName("sex")] public required int Sex { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("photo_url")] public required string PhotoUrl { get; set; }
    [JsonPropertyName("health")] public required int Health { get; set; }
    [JsonPropertyName("damage_per_sec")] public required decimal DamagePerSec { get; set; }
    [JsonPropertyName("bullets_amount")] public required int BulletsAmount { get; set; }
    [JsonPropertyName("move_speed")] public required decimal MoveSpeed { get; set; }
    [JsonPropertyName("weapon_damage")] public required decimal WeaponDamage { get; set; }
    [JsonPropertyName("abilities")] public List<Ability>? Abilities { get; set; }
}