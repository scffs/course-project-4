using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UserPanel.Models;

namespace UserPanel.Services
{
    public class EditProfileService
    {
        private readonly HttpClient _httpClient;

        public EditProfileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> UpdateProfileAsync(int userId, User updatedUser)
        {
            var token = Preferences.Get("auth_token", string.Empty);
            if (string.IsNullOrEmpty(token))
                throw new Exception("Пользователь не авторизован.");

            var request = new HttpRequestMessage(HttpMethod.Patch, $"profile/{userId}")
            {
                Content = new StringContent(JsonSerializer.Serialize(updatedUser), Encoding.UTF8, "application/json")
            };

            // Добавляем заголовок Authorization
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Ошибка обновления профиля: {response.StatusCode} - {errorResponse}");
            }

            return true;
        }
    }
}
