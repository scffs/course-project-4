using AdminPanel.ViewModels;
using Microsoft.Maui.Controls;

namespace AdminPanel;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}