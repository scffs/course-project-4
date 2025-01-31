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
    public ICommand UploadAvatarCommand => new AsyncRelayCommand(UploadAvatarAsync);
    [RelayCommand]
    private async Task RegisterAsync()
    {
        if (IsBusy) return;
        IsBusy = true;
        ErrorMessage = string.Empty;
        try
        {
            var sex = IsMale; // true for male, false for female
            var response = await registerService.RegisterAsync(Name, Surname, Patronymic, sex, Birthday, Login, Password, AvatarUrl ?? "");

            if (string.IsNullOrEmpty(response.Token))
            {
                ErrorMessage = "Ошибка регистрации. Проверьте данные.";
                return;
            }
            // Сохранение токена и пользователя
            Preferences.Set("auth_token", response.Token);
            Preferences.Set("current_user", JsonSerializer.Serialize(response.User));
            // Переход в главное меню
            Application.Current.MainPage = new AppShell();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
        finally
        {
            IsBusy = false;
        }
    }
    private async Task UploadAvatarAsync()
    {
        // Заглушка для загрузки аватара
        AvatarUrl = "https://example.com/avatar.png";
        IsAvatarUploaded = true;
    }
}
