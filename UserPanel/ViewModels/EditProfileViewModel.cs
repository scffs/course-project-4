using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json;
using UserPanel.Models;
using UserPanel.Services;

namespace UserPanel.ViewModels;

public partial class EditProfileViewModel : ObservableObject
{
    private readonly EditProfileService _editProfileService;

    [ObservableProperty] private string name;
    [ObservableProperty] private string surname;
    [ObservableProperty] private string? patronymic;
    [ObservableProperty] private DateTime birthday;
    [ObservableProperty] private string? status;
    [ObservableProperty] private string login;
    [ObservableProperty] private string? avatarUrl;
    [ObservableProperty] private int sexIndex;

    [ObservableProperty] private string errorMessage;
    [ObservableProperty] private bool hasError;

    public int UserId { get; private set; }

    public EditProfileViewModel(EditProfileService editProfileService)
    {
        _editProfileService = editProfileService;
        LoadCurrentUser();
    }

    private void LoadCurrentUser()
    {
        var userJson = Preferences.Get("current_user", string.Empty);
        if (!string.IsNullOrEmpty(userJson))
        {
            var user = JsonSerializer.Deserialize<User>(userJson);
            if (user != null)
            {
                UserId = user.Id;
                Name = user.Name;
                Surname = user.Surname;
                Patronymic = user.Patronymic;
                Birthday = user.Birthday;
                Status = user.Status;
                Login = user.Login;
                AvatarUrl = user.AvatarUrl;
                SexIndex = user.Sex ? 0 : 1;
            }
        }
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        try
        {
            var updatedUser = new User
            {
                Id = UserId,
                Name = Name,
                Surname = Surname,
                Patronymic = Patronymic,
                Birthday = Birthday,
                Status = Status,
                Login = Login,
                AvatarUrl = AvatarUrl,
                Sex = SexIndex == 0
            };
            var success = await _editProfileService.UpdateProfileAsync(UserId, updatedUser);
            if (!success)
                throw new Exception("Ошибка обновления профиля");
            Preferences.Set("current_user", JsonSerializer.Serialize(updatedUser));
            await Shell.Current.GoToAsync("//ProfilePage");
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
            HasError = true;
        }
    }

    [RelayCommand]
    private async Task CancelAsync()
    {
        await Shell.Current.GoToAsync("//ProfilePage");
    }
}
