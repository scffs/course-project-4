using UserPanel.ViewModels;

namespace UserPanel.Views.Profile;

public partial class ProfilePage
{
    public ProfilePage(ProfileViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    private async void OnLogoutClicked(object sender, EventArgs e)
    {
    try
    {
      Preferences.Remove("auth_token");
      await Shell.Current.GoToAsync("//LoginPage");
    }
    catch (Exception err)
    {
      Console.WriteLine(err);
    }
    }
    private async void ToUpdateProfilePage(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//UpdateProfilePage");
    }
}