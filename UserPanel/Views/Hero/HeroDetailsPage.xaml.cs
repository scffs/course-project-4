namespace UserPanel.Views.Hero;

public partial class HeroDetailsPage : ContentPage
{
    public HeroDetailsPage(UserPanel.Models.Hero hero)
    {
        InitializeComponent();
        BindingContext = hero;
    }
}