using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using UserPanel.Models;
using UserPanel.Services;
using UserPanel.Views.Hero;
namespace UserPanel.ViewModels;
public partial class HeroViewModel : ObservableObject
{
    private readonly HeroService _heroService;
    [ObservableProperty] private ObservableCollection<Hero> heroes;
    [ObservableProperty] private Hero? selectedHero;
    public HeroViewModel(HeroService heroService)
    {
        _heroService = heroService;
        LoadHeroes();
    }
    private async void LoadHeroes()
    {
            var heroes = await _heroService.GetHeroesAsync();
            Heroes = new ObservableCollection<Hero>(heroes);
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