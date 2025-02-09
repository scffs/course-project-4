using UserPanel.Models;
namespace UserPanel.Views.Items;

public partial class ItemsDetailsPage : ContentPage
{
    public ItemsDetailsPage(Item item)
    {
        InitializeComponent();
        BindingContext = item;
    }
}