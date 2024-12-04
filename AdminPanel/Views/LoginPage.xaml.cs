using AdminPanel.ViewModels;

namespace AdminPanel;

public partial class LoginPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}