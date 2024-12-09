using UserPanel.Views.Auth;

namespace UserPanel
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new RegisterPage());
        }
        protected override void OnStart()
        {
            base.OnStart();

            var token = Preferences.Get("auth_token", string.Empty);

            if (string.IsNullOrEmpty(token))
                MainPage = new NavigationPage(MauiProgram.ServiceProvider?.GetRequiredService<LoginPage>());
            else
                MainPage = new AppShell();
        }
        protected override void OnStart()
        {
            base.OnStart();

            var token = Preferences.Get("auth_token", string.Empty);

            if (string.IsNullOrEmpty(token))
                MainPage = new NavigationPage(MauiProgram.ServiceProvider?.GetRequiredService<LoginPage>());
            else
                MainPage = new AppShell();
        }
    }
}
