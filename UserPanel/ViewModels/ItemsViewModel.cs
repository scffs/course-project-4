using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using UserPanel.Models;
using UserPanel.Services;

namespace UserPanel.ViewModels;
public partial class ItemsViewModel : ObservableObject
{
    private readonly ItemService _itemService;

    [ObservableProperty] private ObservableCollection<Item> items;
    [ObservableProperty] private bool isBusy;
    [ObservableProperty] private string? errorMessage;

    public ItemsViewModel(ItemService itemService)
    {
        _itemService = itemService;
        LoadItems();
    }

    private async void LoadItems()
    {
        if (IsBusy) return;
        IsBusy = true;

        try
        {
            var items = await _itemService.GetItemsAsync();
            Items = new ObservableCollection<Item>(items);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
        finally
        {
            IsBusy = false;
        }
    }
}