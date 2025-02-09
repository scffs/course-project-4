using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using UserPanel.Models;
using UserPanel.Services;
using UserPanel.Views.Items;
namespace UserPanel.ViewModels;
public partial class ItemViewModel : ObservableObject
{
    private readonly ItemService _itemService;

    [ObservableProperty] private ObservableCollection<Item> items;
    public ItemViewModel(ItemService itemService)
    {
        _itemService = itemService;
        LoadItems();
    }
    private async void LoadItems()
    {
            var items = await _itemService.GetItemsAsync();
            Items = new ObservableCollection<Item>(items);
    }
    [RelayCommand]
    private async void NavigateToItemDetails(Item item)
    {
        if (item != null)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ItemsDetailsPage(item));
        }
    }
}