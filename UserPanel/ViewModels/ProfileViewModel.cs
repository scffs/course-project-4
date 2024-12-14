using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json;
using UserPanel.Models;
using UserPanel.Services;

namespace UserPanel.ViewModels;

public partial class ProfileViewModel : ObservableObject
{
    private readonly AuthService _authService;

    [ObservableProperty] private User? _currentUser;
    [ObservableProperty] private bool _isBusy;
    [ObservableProperty] private string? _errorMessage;

    public ProfileViewModel(AuthService authService)
    {
        _authService = authService;
        LoadUserProfile();
    }

    private void LoadUserProfile()
    {
        var userJson = Preferences.Get("current_user", string.Empty);
        if (!string.IsNullOrEmpty(userJson))
        {
            _currentUser = JsonSerializer.Deserialize<User>(userJson);
        }
    }

    [RelayCommand]
    public async Task LogoutAsync()
    {
        if (_isBusy) return;

        _isBusy = true;
        try
        {
            Preferences.Remove("auth_token");
            Preferences.Remove("current_user");
            await Shell.Current.GoToAsync("//LoginPage");
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
        }
        finally
        {
            _isBusy = false;
        }
    }

    [RelayCommand]
    public async Task EditProfileAsync()
    {
        // Перейти на страницу редактирования профиля
        await Shell.Current.GoToAsync("//EditProfilePage");
    }
}
