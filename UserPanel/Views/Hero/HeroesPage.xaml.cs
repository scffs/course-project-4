using UserPanel.ViewModels;

namespace UserPanel.Views.Hero;

public partial class HeroesPage : ContentPage
{
    public HeroesPage(HeroesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        // Используем heroesCollectionView
        var collectionView = this.FindByName<CollectionView>("heroesCollectionView");
        if (collectionView != null)
        {
            collectionView.SelectionChanged += async (sender, args) =>
            {
                if (args.CurrentSelection.FirstOrDefault() is UserPanel.Models.Hero selectedHero)
                {
                    await Navigation.PushAsync(new HeroDetailsPage(selectedHero));
                    collectionView.SelectedItem = null;
                }
            };
        }
    }
}