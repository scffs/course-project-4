using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using UserPanel.Models;
using UserPanel.Services;

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
}