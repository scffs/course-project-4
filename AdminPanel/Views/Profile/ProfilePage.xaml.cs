namespace AdminPanel.Views.Profile;

public partial class ProfilePage
{
  public ProfilePage()
  {
    InitializeComponent();
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
}