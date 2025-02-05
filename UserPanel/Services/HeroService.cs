using System.Text.Json;
using System.Text.Json.Serialization;
using UserPanel.Models;

namespace UserPanel.Services;
public class HeroService(HttpClient httpClient) : BaseService(httpClient)
{
    public async Task<List<Hero>> GetHeroesAsync()
    {
        var response = await _httpClient.GetAsync("heroes");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Ошибка запроса: {response.StatusCode}");
        }
        var responseBody = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() } // Добавьте необходимые конвертеры
        };
        var result = JsonSerializer.Deserialize<List<Hero>>(responseBody, options);
        if (result == null)
        {
            throw new Exception("Ошибка обработки ответа сервера.");
        }
        return result;
    }
}