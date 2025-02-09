using UserPanel.ViewModels;

namespace UserPanel.Views.Hero;

public partial class HeroesPage : ContentPage
{
    public HeroesPage(HeroViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}