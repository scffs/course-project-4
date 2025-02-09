using UserPanel.ViewModels;
namespace UserPanel.Views.Items;
public partial class ItemsPage : ContentPage
{
    public ItemsPage(ItemViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}