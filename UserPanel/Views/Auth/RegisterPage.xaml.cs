namespace UserPanel.Views.Auth;

public partial class RegisterPage
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