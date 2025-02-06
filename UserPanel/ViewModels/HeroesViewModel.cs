using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using UserPanel.Models;
using UserPanel.Services;
using UserPanel.Views.Hero;

namespace UserPanel.ViewModels;
public partial class HeroesViewModel : ObservableObject
{
    private readonly HeroService _heroService;

    [ObservableProperty] private ObservableCollection<Hero> heroes;
    [ObservableProperty] private bool isBusy;
    [ObservableProperty] private string? errorMessage;
    [ObservableProperty] private Hero? selectedHero;

    public HeroesViewModel(HeroService heroService)
    {
        _heroService = heroService;
        LoadHeroes();
    }

    private async void LoadHeroes()
    {
        if (IsBusy) return;
        IsBusy = true;
        try
        {
            var heroes = await _heroService.GetHeroesAsync();
            Heroes = new ObservableCollection<Hero>(heroes);
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Ошибка: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }
    [RelayCommand]
    private async void NavigateToHeroDetails(Hero hero)
    {
        if (hero != null)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new HeroDetailsPage(hero));
        }
    }
}