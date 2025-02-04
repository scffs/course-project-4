using UserPanel.Models;
namespace UserPanel.Views.Base;

public partial class ArticleDetailsPage : ContentPage
{
    public ArticleDetailsPage(Article article)
    {
        InitializeComponent();
        BindingContext = article;
    }
}