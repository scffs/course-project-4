using UserPanel.Models;
namespace UserPanel.Views.Items;

public partial class DetailsItemPage : ContentPage
{
    public DetailsItemPage(Item item)
    {
        InitializeComponent();
        BindingContext = item;
    }
}