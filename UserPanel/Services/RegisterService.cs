using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UserPanel.Models;

namespace UserPanel.Services;

public class RegisterService
{
    private readonly HttpClient _httpClient;

    public RegisterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AuthResponse> LoginAsync(string name,string surname,string patronymic,bool sex,DateTime birthday,string login, string password, string avatarUrl)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (string.IsNullOrWhiteSpace(surname)) throw new ArgumentNullException(nameof(surname));
        if (bool.IsNullOrWhiteSpace(sex)) throw new ArgumentNullException(nameof(sex));
        if (DateTime.IsNullOrWhiteSpace(birthday)) throw new ArgumentNullException(nameof(birthday));
        if (string.IsNullOrWhiteSpace(login)) throw new ArgumentNullException(nameof(login));
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException(nameof(password));
        if (string.IsNullOrWhiteSpace(avatarUrl)) throw new ArgumentNullException(nameof(avatarUrl));

        var payload = new {name, surname, sex, birthday, login, password, avatarUrl};
        var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync("auth/admin/register", content);

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

