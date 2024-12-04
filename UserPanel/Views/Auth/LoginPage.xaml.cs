using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Maui.Controls.PlatformConfiguration;
using UserPanel.ViewModels;

namespace UserPanel.Views.Auth;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
		InitializeComponent();

        // �������� ������� ��� ��������
        BindingContext = viewModel;
    }

    // ������� ��� ���������
    public Command NavigateToRegisterCommand => new Command(async () =>
    {
        // ������� �� �������� �����������
        await Navigation.PushAsync(new RegisterPage());
    });
    private void OnBigLogoTapped(object sender, TappedEventArgs e)
    {
        // Display an alert with the specified message
        DisplayAlert("������!", "���� � ���� ����� :(", "��");
    }
}