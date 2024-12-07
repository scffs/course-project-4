using System;
using System.Text.Json;
using System.Threading.Tasks;
using UserPanel.Models;
using UserPanel.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace UserPanel.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly AuthService _authService;

    public LoginViewModel(AuthService authService)
    {
        _authService = authService;
    }

    [ObservableProperty] private User? _currentUser;
    [ObservableProperty] private string? _errorMessage;
    [ObservableProperty] private bool _isBusy;
    [ObservableProperty] private string? _login;
    [ObservableProperty] private string? _password;

    [RelayCommand]
    public async Task LoginAsync()
    {
        if (IsBusy) return;
        IsBusy = true;
        ErrorMessage = string.Empty;

        try
        {
            var authResponse = await _authService.LoginAsync(Login, Password);

            if (string.IsNullOrEmpty(authResponse.Token))
            {
                ErrorMessage = "Неверные данные для входа.";
                return;
            }

            CurrentUser = authResponse.User;
            Preferences.Set("auth_token", authResponse.Token);
            Preferences.Set("current_user", JsonSerializer.Serialize<User>(CurrentUser));

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