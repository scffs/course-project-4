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

        var token = Preferences.Get("auth_token", string.Empty);

        if (string.IsNullOrEmpty(token))
            MainPage = new NavigationPage(MauiProgram.ServiceProvider.GetRequiredService<LoginPage>());
        else
            MainPage = new AppShell();
    }
}