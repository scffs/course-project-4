namespace UserPanel.Views.Auth;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();

	}
    // Event handler for the Tapped event on the biglogo image
    private void OnBigLogoTapped(object sender, TappedEventArgs e)
    {
        // Display an alert with the specified message
        DisplayAlert("Больно!", "Себе в глаз тыкни :(", "ОК");
    }
}