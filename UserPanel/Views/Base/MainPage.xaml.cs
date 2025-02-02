using UserPanel.ViewModels;
namespace UserPanel.Views.Base;

public partial class MainPage : ContentPage
{
    public MainPage(ArticlesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel; // Установка ViewModel для страницы
    }
}