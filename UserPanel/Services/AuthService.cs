using UserPanel.Models.Response;

namespace UserPanel.Services;

public class AuthService(HttpClient httpClient) : BaseService(httpClient)
{
    public async Task<AuthResponse> LoginAsync(string login, string password)
    {
        if (string.IsNullOrWhiteSpace(login))
            throw new ArgumentNullException(nameof(login));

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentNullException(nameof(password));

        var payload = new { login, password };

        return await PostAsync<AuthResponse>("auth/login", payload);
    }
}