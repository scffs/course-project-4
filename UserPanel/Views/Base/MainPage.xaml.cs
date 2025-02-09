using UserPanel.ViewModels;
using UserPanel.Models;
using UserPanel.Views;

namespace UserPanel.Views.Base;

public partial class MainPage : ContentPage
{
    public MainPage(ArticleViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}