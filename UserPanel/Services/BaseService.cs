using System.Text;
using System.Text.Json;

namespace UserPanel.Services;

public class BaseService
{
    private readonly HttpClient _httpClient;

    protected BaseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        Console.WriteLine(httpClient);
        if (_httpClient.BaseAddress == null)
        {
            throw new InvalidOperationException("BaseAddress is not set on HttpClient.");
        }

        Console.WriteLine(_httpClient.BaseAddress);
    }

    protected async Task<T> PostAsync<T>(string endpoint, object payload)
    {
        var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(endpoint, content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Ошибка запроса: {response.StatusCode}");
        }

        var responseBody = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<T>(responseBody, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (result == null)
        {
            throw new Exception("Ошибка обработки ответа сервера.");
        }

        return result;
    }
}