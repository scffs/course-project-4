using UserPanel.Models.Response;
namespace UserPanel.Services;
public class RegisterService(HttpClient httpClient) : BaseService(httpClient)
{
    public async Task<AuthResponse> RegisterAsync(string name, string surname, string? patronymic, bool sex,
        DateTime birthday, string login, string password, string avatarUrl)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (string.IsNullOrWhiteSpace(surname)) throw new ArgumentNullException(nameof(surname));
        if (string.IsNullOrWhiteSpace(login)) throw new ArgumentNullException(nameof(login));
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException(nameof(password));
        var payload = new
        {
            name, surname, patronymic, sex, birthday, login, password, avatarUrl
        };
        return await PostAsync<AuthResponse>("auth/register", payload);
    }
}
