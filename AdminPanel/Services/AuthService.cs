using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AdminPanel.Models;

namespace AdminPanel.Services;

public class AuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.example.com");
    }

    public async Task<AuthResponse> LoginAsync(string login, string password)
    {
        var payload = new
        {
            login,
            password
        };

        var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync("auth/login", content);

            if (!response.IsSuccessStatusCode) throw new Exception($"Ошибка авторизации: {response.StatusCode}");

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<AuthResponse>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        catch (Exception ex)
        {
            throw new Exception($"Сетевая ошибка: {ex.Message}");
        }
    }
}