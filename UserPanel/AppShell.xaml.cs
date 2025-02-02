namespace UserPanel;

public partial class AppShell
{
    public AppShell()
    {
        InitializeComponent();

        var token = Preferences.Get("auth_token", string.Empty);

        GoToAsync("//MainPage");
    }

}