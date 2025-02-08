using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using UserPanel.Models;
using UserPanel.Services;
using UserPanel.Views.Items;
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
    [RelayCommand]
    private async void NavigateToItemDetails(Item item)
    {
        if (item != null)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new DetailsItemPage(item));
        }
    }
}