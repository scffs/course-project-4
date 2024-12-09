using UserPanel.ViewModels;

namespace UserPanel.Views.Auth;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
		InitializeComponent();

        // Привязка команды для перехода
        BindingContext = viewModel;
    }
    private async void ToRegisterPage(object? sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new RegisterPage());
    }
    private void OnBigLogoTapped(object sender, TappedEventArgs e)
    {
        // Display an alert with the specified message
        DisplayAlert("Больно!", "Себе в глаз тыкни :(", "ОК");
    }
}