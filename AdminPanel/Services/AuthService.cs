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
    }

    public async Task<AuthResponse> LoginAsync(string login, string password)
    {
        if (string.IsNullOrWhiteSpace(login)) throw new ArgumentNullException(nameof(login));
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException(nameof(password));

        var payload = new { login, password };
        var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync("auth/admin/login", content);

            if (!response.IsSuccessStatusCode) throw new Exception($"Ошибка авторизации: {response.StatusCode}");

            var responseBody = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<AuthResponse>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (result == null) throw new Exception("Ошибка обработки ответа сервера.");

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception($"Сетевая ошибка: {ex.Message}");
        }
    }
}