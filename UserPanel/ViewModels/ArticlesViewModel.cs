using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using UserPanel.Models;
using UserPanel.Services;
using UserPanel.Views.Base;
namespace UserPanel.ViewModels;
public partial class ArticlesViewModel : ObservableObject
{
    private readonly ArticleService _articleService;
    [ObservableProperty] private ObservableCollection<Article> _articles;
    [ObservableProperty] private bool _isBusy;
    [ObservableProperty] private string? _errorMessage;
    public ArticlesViewModel(ArticleService articleService)
    {
        _articleService = articleService;
        LoadArticles();
    }
    private async void LoadArticles()
    {
        if (_isBusy) return;
        _isBusy = true;
        try
        {
            var articles = await _articleService.GetArticlesAsync();
            Articles = new ObservableCollection<Article>(articles);
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
        }
        finally
        {
            _isBusy = false;
        }
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