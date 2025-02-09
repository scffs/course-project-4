using System.Text.Json;
using System.Text.Json.Serialization;
using UserPanel.Models;
namespace UserPanel.Services;
public class ArticleService(HttpClient httpClient) : BaseService(httpClient)
{
    public async Task<List<Article>> GetArticlesAsync()
    {
        var response = await _httpClient.GetAsync("articles");
        var responseBody = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };
        var result = JsonSerializer.Deserialize<List<Article>>(responseBody, options);
        return result;
    }
}