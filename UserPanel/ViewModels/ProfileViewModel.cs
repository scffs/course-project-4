using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json;
using UserPanel.Models;
using UserPanel.Services;
namespace UserPanel.ViewModels;
public partial class ProfileViewModel : ObservableObject
{
    private readonly AuthService _authService;
    [ObservableProperty] private User? currentUser;
    [ObservableProperty] private bool isAuthenticated;
    [ObservableProperty] private bool inverseIsAuthenticated;
    [ObservableProperty] private bool isBusy;
    [ObservableProperty] private string? errorMessage;
    public ProfileViewModel(AuthService authService)
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        CheckAuthenticationState();
        LoadUserProfile();
    }
    private void CheckAuthenticationState()
    {
        var token = Preferences.Get("auth_token", string.Empty);
        IsAuthenticated = !string.IsNullOrEmpty(token);
        InverseIsAuthenticated = !IsAuthenticated;
    }
    private void LoadUserProfile()
    {
        if (IsAuthenticated)
        {
            var userJson = Preferences.Get("current_user", string.Empty);
            if (!string.IsNullOrEmpty(userJson))
            {
                CurrentUser = JsonSerializer.Deserialize<User>(userJson);
            }
        }
    }
    public void SetAuthenticated()
    {
        IsAuthenticated = true;
        InverseIsAuthenticated = false;
        OnPropertyChanged(nameof(IsAuthenticated));
        OnPropertyChanged(nameof(InverseIsAuthenticated));
    }
    public void ClearAuthentication()
    {
        IsAuthenticated = false;
        InverseIsAuthenticated = true;
        OnPropertyChanged(nameof(IsAuthenticated));
        OnPropertyChanged(nameof(InverseIsAuthenticated));
    }
    [RelayCommand]
    public async Task LogoutAsync()
    {
        if (IsBusy) return;
        IsBusy = true;
        try
        {
            bool confirmed = await Application.Current.MainPage.DisplayAlert(
                "Подтверждение выхода",
                "Вы уверены, что хотите выйти из аккаунта?",
                "Да",
                "Отмена"
            );
            if (!confirmed)
            {
                return;
            }
            Preferences.Remove("auth_token");
            Preferences.Remove("current_user");
            ClearAuthentication();
            await Shell.Current.GoToAsync("//MainPage");
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
    [RelayCommand]
    public async Task EditProfileAsync()
    {
        if (!IsAuthenticated || IsBusy) return;
        await Shell.Current.GoToAsync("//EditProfilePage");
    }
    partial void OnIsAuthenticatedChanged(bool oldValue, bool newValue)
    {
        InverseIsAuthenticated = !newValue;
        if (newValue)
        {
            LoadUserProfile();
        }
        else
        {
            CurrentUser = null;
        }
    }
}