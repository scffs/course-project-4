using System.Net.Http;
using System.Text.Json;
using UserPanel.Helpers;
using UserPanel.Models;
using UserPanel.Services;

namespace UserPanel.Services;
public class ItemService(HttpClient httpClient) : BaseService(httpClient)
{
    /// <summary>
    /// Получает список предметов из API.
    /// </summary>
    /// <returns>Список предметов.</returns>
    public async Task<List<Item>> GetItemsAsync()
    {
        var response = await _httpClient.GetAsync("items");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Ошибка запроса: {response.StatusCode}");
        }

        var responseBody = await response.Content.ReadAsStringAsync();

        // Создаем настройки десериализации с кастомным конвертером для boolean
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new BooleanStringConverter() } // Добавляем наш конвертер
        };

        var result = JsonSerializer.Deserialize<List<Item>>(responseBody, options);

        if (result == null)
        {
            throw new Exception("Ошибка обработки ответа сервера.");
        }

        return result;
    }
}