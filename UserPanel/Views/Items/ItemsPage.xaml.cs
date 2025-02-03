using UserPanel.ViewModels;
namespace UserPanel.Views.Items;
public partial class ItemsPage : ContentPage
{
    public ItemsPage(ItemsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}