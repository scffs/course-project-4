using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace UserPanel.Views.Auth;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
		InitializeComponent();

        // Привязка команды для перехода
        BindingContext = this;
    }

    // Команда для навигации
    public Command NavigateToRegisterCommand => new Command(async () =>
    {
        // Переход на страницу регистрации
        await Navigation.PushAsync(new RegisterPage());
    });
    private void OnBigLogoTapped(object sender, TappedEventArgs e)
    {
        // Display an alert with the specified message
        DisplayAlert("Больно!", "Себе в глаз тыкни :(", "ОК");
    }
}