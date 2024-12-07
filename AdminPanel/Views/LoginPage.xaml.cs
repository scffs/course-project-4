using AdminPanel.ViewModels;
using LoginViewModel = AdminPanel.ViewModels.Login.LoginViewModel;

namespace AdminPanel.Views;

public partial class LoginPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}