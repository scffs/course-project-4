using System.Text.Json;
using UserPanel.Helpers;
using UserPanel.Models;
namespace UserPanel.Services;
public class ItemService(HttpClient httpClient) : BaseService(httpClient)
{
    public async Task<List<Item>> GetItemsAsync()
    {
        var response = await _httpClient.GetAsync("items");
        var responseBody = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new BooleanStringConverter() }
        };
        var result = JsonSerializer.Deserialize<List<Item>>(responseBody, options);
        return result;
    }
}