using UserPanel.ViewModels;

namespace UserPanel.Views.Auth;

public partial class LoginPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }


    private async void ToRegisterPage(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }
}