using System.Text.Json;
using System.Windows.Input;
using UserPanel.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UserPanel.ViewModels;

public partial class RegisterViewModel(RegisterService registerService) : ObservableObject
{
    [ObservableProperty] private string? name;
    [ObservableProperty] private string? surname;
    [ObservableProperty] private string? patronymic;
    [ObservableProperty] private bool isMale;
    [ObservableProperty] private bool isFemale;
    [ObservableProperty] private DateTime birthday = DateTime.Now;
    [ObservableProperty] private string? login;
    [ObservableProperty] private string? password;
    [ObservableProperty] private string? avatarUrl;
    [ObservableProperty] private string? errorMessage;
    [ObservableProperty] private bool isBusy;
    [ObservableProperty] private bool isAvatarUploaded;
    [RelayCommand]
    private async Task RegisterAsync()
    {
        if (IsBusy) return;
        IsBusy = true;
        ErrorMessage = string.Empty;

        try
        {
            // Валидация полей
            if (string.IsNullOrWhiteSpace(Name))
            {
                ErrorMessage = "Введите имя.";
                return;
            }

            if (string.IsNullOrWhiteSpace(Surname))
            {
                ErrorMessage = "Введите фамилию.";
                return;
            }

            if (string.IsNullOrWhiteSpace(Login))
            {
                ErrorMessage = "Введите логин.";
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Введите пароль.";
                return;
            }

            if (!IsMale && !IsFemale)
            {
                ErrorMessage = "Выберите ваш пол.";
                return;
            }

            if (Birthday > DateTime.Today)
            {
                ErrorMessage = "Дата рождения не может быть в будущем.";
                return;
            }

            var sex = IsMale; // true для мужского пола, false для женского

            var response = await registerService.RegisterAsync(
                Name,
                Surname,
                Patronymic,
                sex,
                Birthday,
                Login,
                Password,
                AvatarUrl ?? ""
            );

            if (string.IsNullOrEmpty(response.Token))
            {
                ErrorMessage = "Ошибка регистрации. Проверьте данные.";
                return;
            }

            // Сохраняем токен и пользователя
            Preferences.Set("auth_token", response.Token);
            Preferences.Set("current_user", JsonSerializer.Serialize(response.User));

            // Переходим в главное меню
            Application.Current.MainPage = new AppShell();
        }
        catch (Exception ex)
        {
            // Обработка ошибок от сервера
            if (ex is HttpRequestException httpEx && httpEx.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity)
            {
                ErrorMessage = "Ошибка валидации данных. Проверьте правильность введенных данных.";
            }
            else
            {
                ErrorMessage = ex.Message;
            }
        }
        finally
        {
            IsBusy = false;
        }
    }
}
