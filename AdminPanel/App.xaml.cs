using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace AdminPanel;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new LoadingPage();
    }

    protected override async void OnStart()
    {
        base.OnStart();

        var token = await SecureStorage.GetAsync("auth_token");

        if (string.IsNullOrEmpty(token))
            MainPage = new NavigationPage(new LoginPage());
        else
            MainPage = new AppShell();
    }
}