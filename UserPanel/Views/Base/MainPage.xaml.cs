using UserPanel.ViewModels;
using UserPanel.Models;
using UserPanel.Views;

namespace UserPanel.Views.Base;

public partial class MainPage : ContentPage
{
    public MainPage(ArticlesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        // Используем heroesCollectionView
        var collectionView = this.FindByName<CollectionView>("articlesCollectionView");
        if (collectionView != null)
        {
            collectionView.SelectionChanged += async (sender, args) =>
            {
                if (args.CurrentSelection.FirstOrDefault() is Article selectedArticle)
                {
                    await Navigation.PushAsync(new ArticleDetailsPage(selectedArticle));
                    articlesCollectionView.SelectedItem = null;
                }
            };
        }
    }
}
