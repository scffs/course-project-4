using UserPanel.ViewModels;

namespace UserPanel.Views.Profile;

public partial class EditProfilePage : ContentPage
{
	public EditProfilePage(EditProfileViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}