using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using UserPanel.Models;
using UserPanel.Services;
using UserPanel.Views.Base;
namespace UserPanel.ViewModels;
public partial class ArticleViewModel : ObservableObject
{
    private readonly ArticleService _articleService;
    [ObservableProperty] private ObservableCollection<Article> _articles;
    public ArticleViewModel(ArticleService articleService)
    {
        _articleService = articleService;
        LoadArticles();
    }
    private async void LoadArticles()
    {
        var articles = await _articleService.GetArticlesAsync();
        Articles = new ObservableCollection<Article>(articles);
    }
    [RelayCommand]
    private async Task NavigateToArticleDetails(Article article)
    {
        if (article != null)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ArticleDetailsPage(article));
        }
    }
}