using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace UserPanel.Views.Auth;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
		InitializeComponent();

        // �������� ������� ��� ��������
        BindingContext = this;
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