using UserPanel.ViewModels;
namespace UserPanel.Views.Hero;
public partial class HeroesPage : ContentPage
{
	public HeroesPage(HeroesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}