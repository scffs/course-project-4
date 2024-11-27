using System;
using System.Threading.Tasks;
using AdminPanel.Models;
using AdminPanel.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace AdminPanel.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly AuthService _authService;

    [ObservableProperty] private User currentUser;

    [ObservableProperty] private string errorMessage;

    [ObservableProperty] private bool isBusy;

    [ObservableProperty] private string login;

    [ObservableProperty] private string password;

    [RelayCommand]
    public async Task LoginAsync()
    {
        if (IsBusy) return;
        IsBusy = true;
        ErrorMessage = string.Empty;

        try
        {
            var authResponse = await _authService.LoginAsync(Login, Password);

            if (authResponse == null || string.IsNullOrEmpty(authResponse.Token))
            {
                ErrorMessage = "Неверные данные для входа.";
                return;
            }

            CurrentUser = authResponse.User;
            await SecureStorage.SetAsync("auth_token", authResponse.Token);

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
}