using System.Text.Json;
using UserPanel.Models;
using UserPanel.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UserPanel.ViewModels;

public partial class LoginViewModel(AuthService authService) : ObservableObject
{
    [ObservableProperty] private User? _currentUser;
    [ObservableProperty] private string? _errorMessage;
    [ObservableProperty] private bool _isBusy;
    [ObservableProperty] private string? _login;
    [ObservableProperty] private string? _password;

    [RelayCommand]
    private async Task LoginAsync()
    {
        if (IsBusy) return;
        IsBusy = true;
        ErrorMessage = string.Empty;

        try
        {
            var authResponse = await authService.LoginAsync(Login, Password);

            if (string.IsNullOrEmpty(authResponse.Token))
            {
                ErrorMessage = "Неверные данные для входа.";
                return;
            }

            CurrentUser = authResponse.User;
            Preferences.Set("auth_token", authResponse.Token);
            Preferences.Set("current_user", JsonSerializer.Serialize(CurrentUser));

            Application.Current.MainPage = new AppShell();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            ErrorMessage = ex.Message;
        }
        finally
        {
            IsBusy = false;
        }
    }
}