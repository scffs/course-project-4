namespace UserPanel.Views.Auth;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();

	}
    private void OnBigLogoTapped(object sender, TappedEventArgs e)
    {
        DisplayAlert("������!", "���� � ���� ����� :(", "��");
    }
}