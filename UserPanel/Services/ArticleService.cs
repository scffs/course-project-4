using System.Net.Http;
using System.Text.Json;
using UserPanel.Models;
using UserPanel.Services;

namespace UserPanel.Services;
public class ArticleService(HttpClient httpClient) : BaseService(httpClient)
{
    public async Task<List<Article>> GetArticlesAsync()
    {
        var response = await _httpClient.GetAsync("articles");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Ошибка запроса: {response.StatusCode}");
        }

        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<List<Article>>(responseBody, new JsonSerializerOptions
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